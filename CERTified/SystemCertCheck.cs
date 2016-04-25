using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace CERTified
{
    /// <summary>
    /// Class to verify all certificates on the system certificate store.
    /// </summary>
    public class SystemCertCheck
    {
        private readonly List<string> _caStores = new List<string>()
        {
            "Root",
            "AuthRoot"
        };
        private readonly List<string> _certStores = new List<string>()
        {
            "AddressBook",
            "CA",
            "My",
            "Trust",
            "TrustedPeople",
            "TrustedPublisher",
            "Request",
            "Acrs",
            "Spc",
            "NtAuth",
            "Efs",
            "Disallowed"
        };
        private readonly List<string> _allStores = new List<string>()
        {
            "Root",
            "CA",
            "AuthRoot",
            "AddressBook",
            "My",
            "Trust",
            "TrustedPeople",
            "TrustedPublisher",
            "Request",
            "Acrs",
            "Spc",
            "NtAuth",
            "Efs",
            "Disallowed"
        };
        private readonly List<StoreLocation> _storeLocations = new List<StoreLocation>()
        {
            StoreLocation.CurrentUser,
            StoreLocation.LocalMachine
        };

        private readonly CertVerifier _sc;

        /// <summary>
        /// Constructor for Certificate Verifier
        /// </summary>
        public SystemCertCheck()
        {
            _sc = new CertVerifier(GetCrLs());
        }

        /// <summary>
        /// Gets the CertVerifier object
        /// </summary>
        /// <returns>CertVerifier object</returns>
        public CertVerifier GetCertVerifier()
        {
            return _sc;
        }

        /// <summary>
        /// Verifies all certificate authorities and individual certificates with MS CTL and CRL
        /// </summary>
        /// <returns>List of certificate structs</returns>
        public ChangedStruct VerifyAllCerts(List<CertStruct> collection, bool changed=false)
        {
            List<CertStruct> newCollection = new List<CertStruct>(VerifyCAs());
            foreach (var vc in VerifyCerts())
            {
                var found = newCollection.Where(a => a.Thumbprint == vc.Thumbprint);
                if (!found.Any())
                    newCollection.Add(vc);
            }
            if (changed)
                return new ChangedStruct() { Ischanged = changed, Certs = newCollection };
            if (!collection.Any())
                changed = true;
            else
            {
                List<CertStruct> modifiedCollection = new List<CertStruct>();
                _sc.UpdateCrl(GetCrLs());
                ChangedStruct verified = VerifyAllCerts(newCollection, true);
                modifiedCollection.AddRange(verified.Certs);
                foreach (var ac in newCollection)
                {
                    var found = collection.FirstOrDefault(a => a.Thumbprint == ac.Thumbprint);
                    if (String.IsNullOrEmpty(found.Thumbprint))
                    {
                        int idx = modifiedCollection.IndexOf(modifiedCollection.FirstOrDefault(a => a.Thumbprint == ac.Thumbprint));
                        CertStruct moditem = modifiedCollection.ElementAt(idx);
                        moditem.IsNew = true;
                        modifiedCollection.RemoveAt(idx);
                        modifiedCollection.Insert(0, moditem);
                        changed = true;
                    }
                }
                newCollection = modifiedCollection;
            }
            return new ChangedStruct() { Ischanged = changed, Certs = newCollection };
        }

        private string[] GetCrLs()
        {
            HashSet<string> crls = new HashSet<string>();
            foreach (var loc in _storeLocations)
            {
                foreach (var store in _allStores)
                {
                    try
                    {
                        X509Store x509Store = new X509Store(store, loc);
                        x509Store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                        X509CertificateCollection collection = (X509CertificateCollection) x509Store.Certificates;
                        foreach (X509Certificate2 certificate in collection)
                        {
                            X509ExtensionCollection extcol = certificate.Extensions;
                            foreach (var ext in extcol)
                            {
                                if (ext.Oid.FriendlyName == "CRL Distribution Points")
                                {
                                    Regex linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b",
                                        RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                    byte[] test = ext.RawData;
                                    int idxone = test[9];
                                    string crlstr = (Encoding.ASCII.GetString(ext.RawData));
                                    if (linkParser.IsMatch(crlstr))
                                    {
                                        crls.Add(crlstr.Substring(10, idxone));
                                        if (crlstr.Length > idxone + 10)
                                        {
                                            int idxtwo = test[idxone + 17];
                                            crls.Add(crlstr.Substring(idxone + 18, idxtwo));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            string[] crlset = new string[crls.Count];
            crls.CopyTo(crlset);
            return crlset;
        }

        private HashSet<CertStruct> VerifyCAs()
        {
            HashSet<CertStruct> certStruct = new HashSet<CertStruct>();
            foreach (var loc in _storeLocations)
            {
                foreach (var store in _caStores)
                {
                    try
                    {
                        X509Store x509Store = new X509Store(store, loc);
                        x509Store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                        X509CertificateCollection collection = (X509CertificateCollection)x509Store.Certificates;
                        foreach (X509Certificate2 certificate in collection)
                        {
                            var found = certStruct.FirstOrDefault(a => a.Thumbprint == certificate.Thumbprint);
                            if (String.IsNullOrEmpty(found.Thumbprint))
                            {
                                List<Status> stats = new List<Status>();
                                if (!_sc.OnCTL(certificate.Thumbprint))
                                {
                                    stats.Add(Status.Notctl);
                                }
                                if (_sc.OnCrl(certificate.SerialNumber))
                                {
                                    stats.Add(Status.Incrl);
                                }
                                if (!certificate.Verify())
                                {
                                    stats.Add(Status.Invalid);
                                }
                                if ((certificate.NotAfter - DateTime.Now).TotalDays <= 0)
                                {
                                    stats.Add(Status.Expired);
                                }
                                if (stats.Count > 0)
                                {
                                    bool isLocalMachine = loc.ToString().Equals(StoreLocation.LocalMachine.ToString());
                                    certStruct.Add(new CertStruct()
                                    {
                                        Stat = stats,
                                        Storename = store,
                                        Storeloc = loc.ToString(),
                                        Simplename = GetCn(certificate.Subject),
                                        Friendlyname = certificate.FriendlyName,
                                        Serial = certificate.SerialNumber,
                                        Subject = certificate.Subject,
                                        Thumbprint = certificate.Thumbprint,
                                        Algorithm = certificate.SignatureAlgorithm.FriendlyName,
                                        Expires = certificate.NotAfter,
                                        IsNew = false,
                                        IsCa = true,
                                        IsLocalMachine = isLocalMachine
                                    });
                                }
                                certificate.Reset();
                            }
                        }
                        x509Store.Close();
                    }
                    catch (Exception e) { Console.WriteLine(@"Error: {0}", e.Message); }
                }
            }
            return certStruct;
        }

        private HashSet<CertStruct> VerifyCerts()
        {
            HashSet<CertStruct> certStruct = new HashSet<CertStruct>();
            foreach (var loc in _storeLocations)
            {
                foreach (var store in _certStores)
                {
                    try
                    {
                        X509Store x509Store = new X509Store(store, loc);
                        x509Store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                        X509CertificateCollection collection = (X509CertificateCollection) x509Store.Certificates;
                        foreach (X509Certificate2 certificate in collection)
                        {
                            List<Status> stats = new List<Status>();
                            if (_sc.OnCrl(certificate.SerialNumber))
                            {
                                stats.Add(Status.Incrl);
                            }
                            if (!certificate.Verify())
                            {
                                stats.Add(Status.Invalid);
                            }
                            if ((certificate.NotAfter - DateTime.Now).TotalDays <= 0)
                            {
                                stats.Add(Status.Expired);
                            }
                            if (stats.Count > 0)
                            {
                                bool isLocalMachine = loc.ToString().Equals(StoreLocation.LocalMachine.ToString());
                                certStruct.Add(new CertStruct()
                                {
                                    Stat = stats,
                                    Storename = store,
                                    Storeloc = loc.ToString(),
                                    Simplename = GetCn(certificate.Subject),
                                    Friendlyname = certificate.FriendlyName,
                                    Serial = certificate.SerialNumber,
                                    Subject = certificate.Subject,
                                    Thumbprint = certificate.Thumbprint,
                                    Algorithm = certificate.SignatureAlgorithm.FriendlyName,
                                    Expires = certificate.NotAfter,
                                    IsNew = false,
                                    IsCa = false,
                                    IsLocalMachine = isLocalMachine
                                });
                            }
                            certificate.Reset();
                        }
                        x509Store.Close();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }             
                }
            }
            return certStruct;
        }

        private string GetCn(string subject)
        {
            string cn = string.Empty;
            string[] result = subject.Split(',');
            foreach (string r in result)
            {
                if (r.Contains("CN=") || r.Contains("CN ="))
                {
                    cn = r.Split('=')[1];
                    break;
                }
            }
            if (String.IsNullOrEmpty(cn))
            {
                foreach (string r in result)
                {
                    if (r.Contains("OU=") || r.Contains("OU ="))
                    {
                        cn = r.Split('=')[1];
                        break;
                    }
                }
            }
            return cn;
        }
    }
}
