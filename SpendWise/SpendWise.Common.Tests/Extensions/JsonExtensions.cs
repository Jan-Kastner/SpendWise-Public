using Newtonsoft.Json;

namespace SpendWise.Common.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Converts an object to its JSON representation.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}