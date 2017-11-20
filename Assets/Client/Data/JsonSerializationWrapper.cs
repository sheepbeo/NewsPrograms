using System.Text.RegularExpressions;
using UnityEngine;

namespace Client.Data
{
    public class JsonSerializationWrapper
    {
        // TODO Serialization depth limit 7 

        public T Parse<T>(string input, bool UseCamelCase = false)
        {
            if (UseCamelCase)
            {
                input = Regex.Replace(input, @"("")(\w)(\w*"":)", m =>
                    m.Groups[1] + m.Groups[2].ToString().ToUpper() + m.Groups[3]);
            }

            return JsonUtility.FromJson<T>(input);
        }
    }
}