using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMods  
{
    public class AnimationData
    {
       public string Id { get; set; } = "";

    public int[] Frames { get; set; } = Array.Empty<int>();

    public int FrameDuration { get; set; } = 0;

    public bool Loop { get; set; } = false;
    public string NextAnimation { get; set; } = "";
    }
}