using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMods;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;
using StardewValley.Monsters;

namespace P3_ThanatosMods
{
   public static class AnimationDatabase
{
    private static readonly Dictionary<string, AnimationData> animations = new();

    public static void Load(IModHelper helper)
    {
        var list = helper.Data.ReadJsonFile<List<AnimationData>>("assets/animations.json");

        if (list == null)
            return;

        foreach (var data in list)
        {
            animations[data.Id] = data;
        }
    }

    public static AnimationData Get(string id)
    {
        if (animations.TryGetValue(id, out var data))
            return data;

        throw new Exception($"AnimationData not found: {id}");
    }
}
}
