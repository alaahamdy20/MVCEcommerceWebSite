using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MVCEcommerceWebSite.Helpers
{
    public static class SessionHelper
    {
        

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var settings = new JsonSerializerSettings();
            // This tells your serializer that multiple references are okay.
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            session.SetString(key, JsonConvert.SerializeObject(value, settings));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
