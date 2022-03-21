using System;
using System.IO;
using Aquality.Selenium.Browsers;
using Newtonsoft.Json.Linq;

namespace TestProject1.Utils
{
    public static class JsonReader
    {
        public static string GetValueByKey(string path,string key)
        {
            AqualityServices.Logger.Debug($"Read {key} value");
            return (string)JObject.Parse(ReadJsonFile(path))[key];
        }

        private static string ReadJsonFile(string path)
        {
            AqualityServices.Logger.Debug($"Read json file by path: {path}");
            using var sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}