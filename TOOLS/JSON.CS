using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TOOLS
{
    public class JSON
    {
        public object Object { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }

        public string ToString()
        {
            return JsonSerializer.Serialize(Object);
        }

        public static string ToString(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
        public static string ToString<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }


        public object ToObject()
        {
            return JsonSerializer.Deserialize<object>(Text);
        }
        public T ToObject<T>()
        {
            return JsonSerializer.Deserialize<T>(Text);
        }

        public static object ToObject(string txt)
        {
            return JsonSerializer.Deserialize<object>(txt);
        }
        public static T ToObject<T>(string txt)
        {
            return JsonSerializer.Deserialize<T>(txt);
        }
    }
}
