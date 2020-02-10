using Newtonsoft.Json;
using WebApi_PhoneAgg.Converter;

namespace WebApi_PhoneAgg.Models
{
    //[JsonConverter(typeof(SectorConverter))]
    public class Sector
    {
        public int? Technology { get; set; }
        public int? Clothing { get; set; }
        public int? Banking { get; set; }
    }
}
