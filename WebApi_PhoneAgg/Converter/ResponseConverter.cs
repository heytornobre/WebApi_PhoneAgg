using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using WebApi_PhoneAgg.Models;

namespace WebApi_PhoneAgg.Converter
{
    public class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Response).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Response obj = value as Response;
            JToken t = JToken.FromObject(new object[] { obj.Prefixes});
            t.WriteTo(writer);
        }
    }
}
