using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CERTified
{
    /// <summary>
    /// Certificate verification status. INVALID = certificate chain validation failed, NOCTL = not in Microsoft Certificate Trust List,
    /// INCRL = in Certificate Revoked List, EXPIRED = certificate has expired, HASHMISMATCH = certficate hash is mismatched 
    /// </summary>
    public enum Status { INVALID, NOTCTL, INCRL, EXPIRED };

    /// <summary>
    /// Data structure for certificate information
    /// </summary>
    public struct CertStruct
    {
        public List<Status> stat;
        public string storename;
        public string storeloc;
        public string friendlyname;
        public string simplename;
        public string serial;
        public string subject;
        public string thumbprint;
        public string algorithm;
        public DateTime expires;
        public bool isNew;
        public bool isCA;
        public bool isLocalMachine;
    }

    /// <summary>
    /// Contains information about a cert structure to include ischanged
    /// </summary>
    public struct ChangedStruct
    {
        public bool ischanged;
        public List<CertStruct> certs;
    }
}
