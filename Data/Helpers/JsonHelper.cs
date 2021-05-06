using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Data.Helpers
{
    public class JsonFileHelper<T>
    {
        //public static Dictionary<int, T> ReadJson(string JsonFileName)
        //{
        //    string jsonString = File.ReadAllText(JsonFileName);
        //    return JsonConvert.DeserializeObject<Dictionary<int, T>>(jsonString);
        //}
        public static T ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        //public static void WriteToJson(Dictionary<int, T> objects, string JsonFileName)
        //{
        //    string output = Newtonsoft.Json.JsonConvert.SerializeObject(objects,
        //                                                       Newtonsoft.Json.Formatting.Indented);

        //    File.WriteAllText(JsonFileName, output);
        //}
        public static void WriteToJson(T objects, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(objects,
                                                               Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
        public static void ClearJson(string JsonFileName)
        {
            File.WriteAllText(JsonFileName, string.Empty);
        }
    }
}
