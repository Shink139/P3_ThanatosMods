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
    public class NPCData
    {
        public string Name { get; set; } = "";
        public string Id { get; set; } = "";
        public List<string> Skills { get; set; } = new();
    }
}