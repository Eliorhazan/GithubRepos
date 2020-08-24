using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
    The SessionExtension class use for as halper class.
    Contains set and get method of complex objects
    to manipulate with sessions.
*/
namespace GithubRepos
{
    public static class SessionExtension
    {
        //parmas: key value pair to set session and session interface
        //value parameter is complex object and setString method serialize it
        public static void SetObject(this ISession session, string key, object value)
        {

            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        //parmas: key  and session interface
        //return: value type of T
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
