using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

public static class Commons
{
    /// <summary>
    /// Try to get from tag, else return specified default. Supports int, float, double, bool, long, and string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tag"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static T TryGet<T>(TagCompound tag, string key, T defaultValue)
    {
        try
        {
            T val;
            Type type = typeof(T);
            if (type == typeof(int)) val = (T)Convert.ChangeType(tag.GetInt(key), type);
            else if (type == typeof(float)) val = (T)Convert.ChangeType(tag.GetFloat(key), type);
            else if (type == typeof(double)) val = (T)Convert.ChangeType(tag.GetDouble(key), type);
            else if (type == typeof(bool)) val = (T)Convert.ChangeType(tag.GetBool(key), type);
            else if (type == typeof(long)) val = (T)Convert.ChangeType(tag.GetLong(key), type);
            else if (type == typeof(string)) val = (T)Convert.ChangeType(tag.GetString(key), type);
            else throw new Exception();

            return val;
        }
        catch
        {
            return defaultValue;
        }
    }

}