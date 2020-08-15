using Newtonsoft.Json;

namespace Ax3.IMS.Infrastructure.Utils
{
    public static class JSONSerializer
    {
        public static string ToJSON(this object serializedObject)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(serializedObject, (Formatting)0, serializerSettings);
        }

        public static string ToJSON(
          this object serializedObject,
          JsonSerializerSettings serializerSettings)
        {
            return JsonConvert.SerializeObject(serializedObject, (Formatting)0, serializerSettings);
        }

        public static T DeserializeJSON<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}