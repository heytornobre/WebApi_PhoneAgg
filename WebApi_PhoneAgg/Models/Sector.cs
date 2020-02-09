using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_PhoneAgg.Models
{

    public class Sector
    {
        private Sector(string name) { Name = name; }

        public string Name { get; set; }

        public static Sector Technology { get { return new Sector("Technology"); } }
        public static Sector Banking { get { return new Sector("Banking"); } }
        public static Sector Clothing { get { return new Sector("Clothing"); } }
    }
}
