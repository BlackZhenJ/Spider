using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Globals
    {
        public static string JsonToString<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static T StringToJson<T>(string model)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(model);
        }
    }
}
