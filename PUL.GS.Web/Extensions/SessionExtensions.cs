using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PUL.GS.Web.Extensions
{
    /// <summary>
    /// Class for Session extensions
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Sets key and value for session extension
        /// </summary>
        /// <typeparam name="T">Session type (class)</typeparam>
        /// <param name="session">Current Session</param>
        /// <param name="key">Extension Key</param>
        /// <param name="value">Extension Value</param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Gets session extension by key
        /// </summary>
        /// <typeparam name="T">Session type (class)</typeparam>
        /// <param name="session">Current Session</param>
        /// <param name="key">Extension Key</param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
