using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApi_PhoneAgg.Models;

namespace WebApi_PhoneAgg.Converter
{
    public class PrefixConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Prefix).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            Prefix obj = value as Prefix;

            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            string dataPropertyName = (string)type.GetProperty("Number", bindingFlags).GetValue(value);
            if (string.IsNullOrEmpty(dataPropertyName))
            {
                dataPropertyName = "Data";
            }

            JObject jo = new JObject();
            jo.Add(dataPropertyName, JToken.FromObject(obj.Sectors));
            jo.WriteTo(writer);
        }

        static IEnumerable<JsonProperty> SerializableProperties(JsonObjectContract contract)
        {
            return contract.Properties.Where(p => !p.Ignored && p.Readable && p.Writable);
        }
    }
}
