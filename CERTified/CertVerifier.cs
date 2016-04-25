using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Deployment.Compression.Cab;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;

namespace CERTified
{
    /// <summary>
    /// Class to download MS CTL and CRLs and verify target certificates
    /// </summary>
    public class CertVerifier
    {
        private readonly string[] _winCTL = { @"http://ctldl.windowsupdate.com/msdownload/update/v3/static/trustedr/en/authrootstl.cab" };
        private string[] _3pcrls;
        private readonly List<string> _ctls = new List<string>();
        private readonly HashSet<X509Crl> _crls = new HashSet<X509Crl>();
        private readonly List<string> _octetstrings = new List<string>();

        /// <summary>
        /// Constructor for Cerificate Verifier. Begins download and parsing of CTL and CRL
        /// </summary>
        public CertVerifier()
        {
            GetWinCTL();
        }

        /// <summary>
        /// Constructor for Cerificate Verifier. Begins download and parsing of CTL and CRL
        /// </summary>
        /// <param name="crls">3d party CRL lists from system certificates</param>
        public CertVerifier(string[] crls)
        {
            _3pcrls = crls;
            GetWinCTL();
            GetCRLs();
        }

        /// <summary>
        /// Updates the 3d party certificate revocation list
        /// </summary>
        /// <param name="newcrls">updated crl</param>
        public void UpdateCRL(string[] newcrls)
        {
            _3pcrls = newcrls;
            GetCRLs();
        }

        /// <summary>
        /// Is certificate thumbprint on MS Certificate Trust List
        /// </summary>
        /// <param name="thumbprint">Certificate thumbprint</param>
        /// <returns>If thumbprint is in Certificate Trust List</returns>
        public bool OnCTL(string thumbprint)
        {
            bool result = false;
            foreach (var c in _ctls)
            {
                if (c.Equals(thumbprint.ToUpper()))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Is certificate on Certificate Revocation List
        /// </summary>
        /// <param name="cert">X509Certificate structure</param>
        /// <returns>If thumbprint is in Certificate Revokation List</returns>
        public bool OnCRL(X509Certificate cert)
        {
            bool result = false;
            foreach (var x in _crls)
            {
                if (x.IsRevoked(cert))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Is certificate serial number on Certificate Revocation List
        /// </summary>
        /// <param name="serial">Certificate serial number</param>
        /// <returns>If serial number is in Certificate Revocation List</returns>
        public bool OnCRL(string serial)
        {
            bool result = false;
            foreach (var x in _crls)
            {
                if (!result)
                {
                    BigInteger biserial = new BigInteger(serial.ToUpper(), 16);
                    Asn1InputStream asn1 = new Asn1InputStream(x.GetEncoded());
                    Asn1Sequence seq = (Asn1Sequence)asn1.ReadObject();
                    CertificateList cl = CertificateList.GetInstance(seq);
                    IEnumerable revoked = cl.GetRevokedCertificateEnumeration();
                    foreach (var r in revoked)
                    {
                        CrlEntry crle = (CrlEntry)r;
                        if (BigInteger.Equals(biserial, crle.UserCertificate.Value))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
           
        }

        /// <summary>
        /// Download, unpack, and parse MS Certificate Trust List
        /// </summary>
        public void GetWinCTL()
        {
            _ctls.Clear();
            foreach (string url in _winCTL)
            {
                byte[] data = WebDownload(url);
                UnpackCAB(data);
            }
        }

        /// <summary>
        /// Download and parse Certificate Revocation List
        /// </summary>
        public void GetCRLs()
        {
            _crls.Clear();
            foreach (string url in _3pcrls)
            {
                byte[] data = WebDownload(url);
                if (data != null)
                    _crls.Add(BuildCRL(data));
            }
        }

        private X509Crl BuildCRL(byte[] data)
        {
            X509Crl crls = null;
            try
            {
                X509CrlParser crlp = new X509CrlParser();
                crls = crlp.ReadCrl(data);
            }
            catch (Exception e) { Console.WriteLine(@"Eror: Could not parse CRL. {0}", e.Message); }
            return crls;
        }

        private void UnpackCAB(byte[] data)
        {
            try
            {
                CabEngine engine = new CabEngine();
                Stream s = new MemoryStream(data);
                foreach (var archiveFileInfo in engine.GetFiles(s))
                {
                    try
                    {
                        Stream stream = engine.Unpack(s, archiveFileInfo);
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, (int)stream.Length);
                        DecodeASN1(buffer);
                        ParseHashes();
                    }
                    catch (Exception e) { Console.WriteLine(@"Error: Could not parse CTL. {0}", e.Message); }
                }
            }
            catch (Exception e) { Console.WriteLine(@"Error: {0}", e.Message); }
        }

        private void DecodeASN1(byte[] data)
        {
            Asn1InputStream input = new Asn1InputStream(data);
            Asn1Sequence seq = (Asn1Sequence)input.ReadObject();
            foreach (var s in seq)
            {
                if (s.GetType() == typeof(DerTaggedObject))
                {
                    DecodeASN1((DerTaggedObject)s);
                }
            }
        }

        private void DecodeASN1(DerTaggedObject dto)
        {            
            Asn1Sequence seq = (Asn1Sequence)dto.GetObject();
            foreach (var s in seq)
            {
                if (s.GetType() == typeof(DerSequence))
                {
                    DecodeASN1((DerSequence)s);
                }
            }
        }

        private void DecodeASN1(DerSequence dseq)
        {
            Asn1Sequence seq = (Asn1Sequence)dseq;
            foreach (var s in seq)
            {
                if (s.GetType() == typeof(Org.BouncyCastle.Asn1.DerSequence))
                {
                    DecodeASN1((DerSequence)s);
                }
                if (s.GetType() == typeof(DerTaggedObject))
                {
                    DecodeASN1((DerTaggedObject)s);
                }
                if (s.GetType() == typeof(DerOctetString))
                {
                    _octetstrings.Add(s.ToString());
                }
            }
        }

        private void ParseHashes()
        {
            foreach (var o in _octetstrings)
            {
                _ctls.Add(o.Replace("#", "").ToUpper());
            }
        }

        private byte[] WebDownload(string URL)
        {
            byte[] data = null;
            try
            {
                WebClient client = new WebClient();
                data = client.DownloadData(URL);
            }
            catch (Exception e) { Console.WriteLine(@"Error: Could not download {0}. {1}", URL, e.Message); }
            return data;
        }
    }
}
