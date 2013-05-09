using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoJ
{
    public class Config
    {
        private const string CONFIGFILE = "settings.json";
        private Dictionary<string, string> values = new Dictionary<string, string>();
        private TaskCollection _tasks = new TaskCollection();


        public Dictionary<string, string> Values
        {
            get { return values; }
            set { values = value; }
        }

        public string Get(string key)
        {
            if (values.ContainsKey(key)) return values[key];
            return string.Empty;
        }

        public void Set(string key, string value)
        {
            if (values.ContainsKey(key))
            {
                values[key] = value;
            }
            else
            {
                values.Add(key, value);
            }
        }

        public TaskCollection Tasks
        {
            get
            {
                if (_tasks == null) _tasks = new TaskCollection();
                return _tasks;
            }
            set { _tasks = value; }
        }


        public static Config LoadConfig()
        {
            return LoadConfig(CONFIGFILE);
        }

        public static Config LoadConfig(string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                try
                {
                    var text = System.IO.File.ReadAllText(CONFIGFILE);
                    var config = JsonConvert.DeserializeObject<Config>(text);
                    return config;
                }
                catch (Exception ex)
                {
                    
                    return new Config();
                }
            }
            return new Config();
        }

        public void Save()
        {
            SaveConfig(CONFIGFILE);
        }
        public void SaveConfig(string filename)
        {
            string output = JsonConvert.SerializeObject(this, Formatting.Indented);
            System.IO.File.WriteAllText(filename, output);

        }

        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented);
        }

    }


}
