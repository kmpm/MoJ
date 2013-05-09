// Copyright (C) 2013 Peter Magnusson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MoJ
{
    public class MojStringEnumConverter : Newtonsoft.Json.Converters.StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type t = value.GetType();
            if (t.IsEnum)
            {
                writer.WriteValue(Enum.GetName(t, value));
                return;
            }

            //if (value is T)
            //{
            //    writer.WriteValue(Enum.GetName(typeof(T), (T)value));// or something else
            //    return;
            //}

            base.WriteJson(writer, value, serializer);
        }
    }
}
