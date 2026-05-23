using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMods  
{
public class AnimationState
{
    public AnimationData Data;

    public int FrameIndex;

    public int Timer;

    public bool Finished;

    public AnimationState(AnimationData data)
    {
        Data = data;

        FrameIndex = 0;
        Timer = 0;
        Finished = false;
    }
}}