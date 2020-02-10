using Newtonsoft.Json;
using System.Collections.Generic;
using WebApi_PhoneAgg.Converter;

namespace WebApi_PhoneAgg.Models
{
    [JsonConverter(typeof(PrefixConverter))]
    public class Prefix
    {
        public string Number { get; set; }
        public Sector Sectors { get; set; }
    }
}
