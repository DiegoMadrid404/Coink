namespace Proyecto.IC.Utilidades.Genericos
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConvertidorLista<TC, TA> : JsonConverter where TC : TA
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IList<TA>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IList<TC> items = serializer.Deserialize<List<TC>>(reader);
            if (items == null)
            {
                return new List<TC>().Cast<TA>().ToList();
            }
            return items.Cast<TA>().ToList();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(IList<TC>));
        }
    }
}