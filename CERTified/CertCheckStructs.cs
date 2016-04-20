using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CERTified
{
    /// <summary>
    /// Certificate verification status. INVALID = certificate chain validation failed, NOCTL = not in Microsoft Certificate Trust List,
    /// INCRL = in Certificate Revoked List, EXPIRED = certificate has expired, HASHMISMATCH = certficate hash is mismatched 
    /// </summary>
    public enum status { INVALID, NOTCTL, INCRL, EXPIRED, HASHMISMATCH };

    /// <summary>
    /// Data structure for certificate information
    /// </summary>
    public struct certstruct
    {
        public List<status> stat;
        public string storename;
        public string friendlyname;
        public string simplename;
        public string serial;
        public string thumbprint;
        public string algorithm;
        public DateTime expires;
    }
}
