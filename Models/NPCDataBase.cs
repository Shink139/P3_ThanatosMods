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

public static class NPCDatabase
{
    public static Dictionary<string, NPCData> NPCs { get; private set; }
        = new Dictionary<string, NPCData>();

    public static void Load(IModHelper helper)
    {
        List<NPCData> list =
            helper.Data.ReadJsonFile<List<NPCData>>("assets/npcs.json")
            ?? new List<NPCData>();

        NPCs = list.ToDictionary(n => n.Id, n => n);
    }

    public static NPCData Get(string id)
    {
        return NPCs[id];
    }
}
}