namespace Proyecto.IC.Utilidades.Genericos
{
    using Newtonsoft.Json;
    using System;

    public class ConvertidorEntidad<TC, TA> : JsonConverter where TC : TA
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TA);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TC>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(TC));
        }
    }
}