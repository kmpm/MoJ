using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MoJ
{
    public static class Config
    {
        private static string filename = "settings.txt";
        private static Dictionary<string, string> values = new Dictionary<string,string>();
        static Config()
        {
            if (System.IO.File.Exists(filename))
            {
                var sr = System.IO.File.OpenText(filename);
                string s = sr.ReadToEnd();
                sr.Close();
                string[] lines = s.Split('\n');
                foreach (string line in lines)
                {
                    string[] kv = line.Split('=');
                    if (kv.Length != 2) continue;
                    string k = kv[0].Trim();
                    string v = kv[1].Trim();
                    values.Add(k, v);
                
                }
               
            }
        }

        public static void Save()
        {
            string c="";
            foreach (string key in values.Keys)
            {
                c += String.Format("{0}={1}\n", key, values[key]);
            }
            System.IO.File.WriteAllText(filename, c);
            
        }

        public static string Get(string key)
        {
            if (values.ContainsKey(key)) return values[key];
            return string.Empty;
        }

        public static void Set(string key, string value)
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
    }


}
