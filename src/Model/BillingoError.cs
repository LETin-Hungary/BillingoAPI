using System.Collections.Generic;

namespace LETin.BillingoAPI
{
    public class BillingoError
    {
        public string Error { get; set; }
        public ICollection<string> Errors { get; set; }
        public bool Success { get; set; }
    }
}