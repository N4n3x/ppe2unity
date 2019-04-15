using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace apiModele
{
    public static class JsonClass
    {
        public static T[] ArrayFromJson<T>(string json)
        {
            string newJson = "{ \"Items\": " + json + "}";
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.Items;
        }

        public static T OneFromJson<T>(string json)
        {
            string newJson = "{ \"Items\": " + json + "}";
            var wrapper = JsonUtility.FromJson<OneWrapper<T>>(newJson);
            return wrapper.Items;
        }

        public static T[] FromJsonString<T>(string json)
        {
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }


        public static string ArrayToJsonString<T>(T[] array)
        {
            var wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ArrayToJsonString<T>(T[] array, bool prettyPrint)
        {
            var wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }

        [Serializable]
        private class OneWrapper<T>
        {
            public T Items;
        }

    }
}

