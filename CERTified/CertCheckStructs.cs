using System;
using System.Collections.Generic;

namespace CERTified
{
    /// <summary>
    /// Certificate verification status. INVALID = certificate chain validation failed, NOCTL = not in Microsoft Certificate Trust List,
    /// INCRL = in Certificate Revoked List, EXPIRED = certificate has expired, HASHMISMATCH = certficate hash is mismatched 
    /// </summary>
    public enum Status { Invalid, Notctl, Incrl, Expired };

    /// <summary>
    /// Data structure for certificate information
    /// </summary>
    public struct CertStruct
    {
        public List<Status> Stat;
        public string Storename;
        public string Storeloc;
        public string Friendlyname;
        public string Simplename;
        public string Serial;
        public string Subject;
        public string Thumbprint;
        public string Algorithm;
        public DateTime Expires;
        public bool IsNew;
        public bool IsCa;
        public bool IsLocalMachine;
    }

    /// <summary>
    /// Contains information about a cert structure to include ischanged
    /// </summary>
    public struct ChangedStruct
    {
        public bool Ischanged;
        public List<CertStruct> Certs;
    }
}
