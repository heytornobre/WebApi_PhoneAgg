using Newtonsoft.Json;
using WebApi_PhoneAgg.Converter;

namespace WebApi_PhoneAgg.Models
{
    [JsonConverter(typeof(SectorConverter))]
    public class Sector
    {
        public Sector(string key, int v)
        {
            Name = key;
            Count = v;
        }

        public string Name { get; set; }
        public int Count { get; set; }
    }
}
