using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_PhoneAgg.Models
{
    public class Prefix
    {
        public int Number { get; set; }
        public List<KeyValuePair<string,int>> Sectors{get; set;}
    }
}
