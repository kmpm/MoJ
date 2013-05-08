using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MoJ
{
    [JsonConverter(typeof(MojStringEnumConverter))]
    public enum ActionMethod
    {
        KeyDown,
        KeyUp,
        KeyPress,
        MouseButtonDown,
        MouseButtonUp,
        MouseButtonClick
    }



    public class Action
    {
        public ActionMethod Method { get; set; }

        public String Data { get; set; }

        public int Delay { get; set; }
    }

}
