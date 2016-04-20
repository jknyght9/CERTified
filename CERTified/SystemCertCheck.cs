using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CERTified
{
    /// <summary>
    /// Class to verify all certificates on the system certificate store.
    /// </summary>
    public class SystemCertCheck
    {
        private CertVerifier _sc;

        /// <summary>
        /// Constructor for Certificate Verifier
        /// </summary>
        public SystemCertCheck()
        {
            _sc = new CertVerifier();
        }

        /// <summary>
        /// Gets the CertVerifier object
        /// </summary>
        /// <returns>CertVerifier object</returns>
        public CertVerifier getCertVerifier()
        {
            return _sc;
        }

        /// <summary>
        /// Verifies all certificate authorities and individual certificates with MS CTL and CRL
        /// </summary>
        /// <returns>List of certificate structs</returns>
        public List<certstruct> verifyAllCerts()
        {
            List<certstruct> result = new List<certstruct>();
            result.AddRange(verifyCAs());
            result.AddRange(verifyCerts());
            return result;
        }

        private List<certstruct> verifyCAs()
        {
            List<StoreName> stores = new List<StoreName>()
            {
                    StoreName.Root,                     //root CAs
                    StoreName.AuthRoot                 //3d party CAs
                    //StoreName.CertificateAuthority      //intermediate CAs
            };
            List<StoreLocation> locs = new List<StoreLocation>()
            {
                //StoreLocation.CurrentUser,
                StoreLocation.LocalMachine
            };
            List<certstruct> certstruct = new List<certstruct>();

            foreach (var loc in locs)
            {
                foreach (var store in stores)
                {
                    X509Store x509store = new X509Store(store, loc);
                    x509store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                    X509CertificateCollection collection = (X509CertificateCollection)x509store.Certificates;
                    foreach (X509Certificate2 certificate in collection)
                    {
                        try
                        {
                            List<status> stats = new List<status>();
                            if (!_sc.onCTL(certificate.Thumbprint))
                            {
                                stats.Add(status.NOTCTL);
                            }
                            if (_sc.onCRL(certificate.SerialNumber))
                            {
                                stats.Add(status.INCRL);
                            }
                            if (!certificate.Verify())
                            {
                                stats.Add(status.INVALID);
                            }
                            if ((certificate.NotAfter - DateTime.Now).TotalDays <= 0)
                            {
                                stats.Add(status.EXPIRED);
                            }
                            if (!verifyHashes(certificate.GetRawCertData(), certificate.GetCertHashString()))
                            {
                                stats.Add(status.HASHMISMATCH);
                            }
                            if (stats.Count > 0)
                            {
                                certstruct.Add(new certstruct()
                                {
                                    stat = stats,
                                    storename = (store.ToString().Equals("My")) ? "Personal" : store.ToString(),
                                    simplename = certificate.GetNameInfo(X509NameType.SimpleName, true),
                                    friendlyname = certificate.FriendlyName,
                                    serial = certificate.SerialNumber,
                                    thumbprint = certificate.Thumbprint,
                                    algorithm = certificate.SignatureAlgorithm.FriendlyName,
                                    expires = certificate.NotAfter
                                });
                            }
                            certificate.Reset();
                        }
                        catch (Exception e) { Console.WriteLine("Error: {0}", e.Message); }
                    }
                    x509store.Close();
                }
            }
            return certstruct;
        }

        private List<certstruct> verifyCerts()
        {
            List<StoreName> stores = new List<StoreName>()
            {
                    StoreName.My,
                    StoreName.TrustedPeople,
                    StoreName.TrustedPublisher
            };
            List<StoreLocation> locs = new List<StoreLocation>()
            {
                //StoreLocation.CurrentUser,
                StoreLocation.LocalMachine
            };
            List<certstruct> certstruct = new List<certstruct>();

            foreach (var loc in locs)
            {
                foreach (var store in stores)
                {
                    X509Store x509store = new X509Store(store, loc);
                    x509store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                    X509CertificateCollection collection = (X509CertificateCollection)x509store.Certificates;
                    foreach (X509Certificate2 certificate in collection)
                    {
                        try
                        {
                            List<status> stats = new List<status>();
                            if (_sc.onCRL(certificate.SerialNumber))
                            {
                                stats.Add(status.INCRL);
                            }
                            if (!certificate.Verify())
                            {
                                stats.Add(status.INVALID);
                            }
                            if ((certificate.NotAfter - DateTime.Now).TotalDays <= 0)
                            {
                                stats.Add(status.EXPIRED);
                            }
                            if (!verifyHashes(certificate.GetRawCertData(), certificate.GetCertHashString()))
                            {
                                stats.Add(status.HASHMISMATCH);
                            }
                            if (stats.Count > 0)
                            {
                                certstruct.Add(new certstruct()
                                {
                                    stat = stats,
                                    storename = (store.ToString().Equals("My")) ? "Personal" : store.ToString(),
                                    simplename = certificate.GetNameInfo(X509NameType.SimpleName, true),
                                    serial = certificate.SerialNumber,
                                    thumbprint = certificate.Thumbprint,
                                    algorithm = certificate.SignatureAlgorithm.FriendlyName,
                                    expires = certificate.NotAfter
                                });
                            }
                            certificate.Reset();
                        }
                        catch (Exception e) { Console.WriteLine("Error: {0}", e.Message); }
                    }
                    x509store.Close();
                }
            }
            return certstruct;
        }

        private bool verifyHashes(byte[] certdata, string hash)
        {
            bool result = true;
            SHA1Managed sha = new SHA1Managed();
            byte[] sha1hash = sha.ComputeHash(certdata);
            string wedontneednostinkinghashes = BitConverter.ToString(sha1hash).Replace("-", "");
            if (!hash.Equals(BitConverter.ToString(sha1hash).Replace("-", "")))
            {
                result = false;
            }
            return result;
        }
    }
}
