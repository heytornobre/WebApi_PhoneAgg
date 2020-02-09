using Newtonsoft.Json;
using System.Collections.Generic;
using WebApi_PhoneAgg.Converter;

namespace WebApi_PhoneAgg.Models
{
    [JsonConverter(typeof(PrefixConverter))]
    public class Prefix
    {
        public int Number { get; set; }
        public List<Sector> Sectors{get; set;}
    }
}
