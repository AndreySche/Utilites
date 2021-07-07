using UnityEngine;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Json
{
    class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            //if (json.Substring(0, 1) == "{") json = $"[{json}]"; // andreySche
            //string newJson = "{ \"array\": " + json + "}"; // andreySche
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.array;
        }

        public static string ToJson<T>(T[] array, bool prettyPrint = false)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.array = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }

        public static string Unicode(string result)
        {
            Regex rx = new Regex(@"\\[uU]([0-9A-F]{4})");
            return rx.Replace(result, match => ((char) int.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString());
        }
    }
}