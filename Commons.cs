using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

public static class Commons
{
    /// <summary>
    /// Creates and finalizes a recipe. Ingredients must be formatted new int[,] { {id1, num1}, {id2, num2}, ... }. Can build on an existing recipe.
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="ingredients"></param>
    /// <param name="result"></param>
    /// <param name="numResult"></param>
    /// <param name="where"></param>
    public static void QuckRecipe(Mod mod, int[,] ingredients, ModItem result, int numResult = 1, ModRecipe buildOn = null, ushort where = TileID.WorkBenches)
    {
        //recipe
        ModRecipe recipe;
        if (buildOn == null) recipe = new ModRecipe(mod);
            else recipe = buildOn;

        //where to craft (use MaxValue to skip)
        if (where != ushort.MaxValue) recipe.AddTile(where);

        //add ingredients
        if (ingredients.GetLength(1) == 2)
        {
            for (int i = 0; i < ingredients.GetLength(0); i++)
            {
                recipe.AddIngredient(ingredients[i, 0], ingredients[i, 1]);
            }
        }

        //result
        recipe.SetResult(result, numResult);

        //complete
        recipe.AddRecipe();
    }

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