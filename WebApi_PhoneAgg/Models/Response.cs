using Newtonsoft.Json;
using System.Collections.Generic;
using WebApi_PhoneAgg.Converter;

namespace WebApi_PhoneAgg.Models
{
    [JsonConverter(typeof(ResponseConverter))]
    public class Response
    {
        public List<Prefix> Prefixes { get; set; }
    }
}
