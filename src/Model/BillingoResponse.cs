using System.Collections.Generic;

namespace LETin.BillingoAPI
{
    public class BillingoResponse<T>
    {
        public string Type { get; set; }
        public ICollection<T> Data { get; set; }
        public bool Success { get; set; }
    }
}