using System;
using System.Collections.Generic;
using System.Text;

namespace LETin.Billingo.AspNetCore
{
    public class BillingoOptions
    {
        public double TokenExpireSeconds { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string IssuerUri { get; set; }
        public BillingoOptions()
        {
            TokenExpireSeconds = 30;
        }
    }
}
