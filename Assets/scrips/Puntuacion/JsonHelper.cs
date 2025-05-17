using System;
using UnityEngine;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(WrapArray(json));
        return wrapper.Items;
    }

    private static string WrapArray(string json)
    {
        return "{\"Items\":" + json + "}";
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
