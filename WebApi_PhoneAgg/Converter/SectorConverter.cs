using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_PhoneAgg.Models;
namespace WebApi_PhoneAgg.Converter
{
    public class SectorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Sector).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("invalid type {0}.", objectType.FullName));

            writer.WriteStartArray();
            foreach (var property in SerializableProperties(contract))
            {
                var propertyValue = property.ValueProvider.GetValue(value);
                if (property.Converter != null && property.Converter.CanWrite)
                    property.Converter.WriteJson(writer, propertyValue, serializer);
                else
                    serializer.Serialize(writer, propertyValue);
            }
            writer.WriteEndArray();
        }

        static IEnumerable<JsonProperty> SerializableProperties(JsonObjectContract contract)
        {
            return contract.Properties.Where(p => !p.Ignored && p.Readable && p.Writable);
        }
    }
}
