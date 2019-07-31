using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPIcore.Models
{
    public class Page
    {
        public int id { get; set; }
        public string title { get; set; }
        public string snippet { get; set; }
        public DateTime timestamp { get; set; }
    }
}
