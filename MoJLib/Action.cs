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
        TextEntry,
        MouseButtonDown,
        MouseButtonUp,
        MouseButtonClick
    }


    public class Action
    {
        private ActionMethod _method = ActionMethod.MouseButtonClick;
        private String _data = String.Empty;
        private int _delay = 0;

        public event EventHandler PropertyChanged;

        public ActionMethod Method
        {
            get { return _method; }
            set
            {
                _method = value;
                OnPropertyChanged("Method");
            }
        }

        public String Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

        public int Delay
        {
            get { return _delay; }
            set
            {
                _delay = value;
                OnPropertyChanged("Delay");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new EventArgs());
            }
        }
    }

}
