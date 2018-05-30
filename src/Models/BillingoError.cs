using System.Collections.Generic;

namespace LETin.BillingoAPI.Models
{
    public class BillingoError
    {
        public string Error { get; set; }
        public ICollection<string> Errors { get; set; }
        public bool Success { get; set; }
    }
}