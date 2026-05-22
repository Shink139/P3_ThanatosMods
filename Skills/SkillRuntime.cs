using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMod;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;
using StardewValley.Monsters;
namespace P3_ThanatosMods
{
    public class SkillRuntime
{
    public SkillData Data { get; }
    public int LastUsedTick { get; private set; } = -999999;

    public SkillRuntime(SkillData data)
    {
        Data = data;
    }

    public bool IsReady(int currentTick)
    {
        return currentTick - LastUsedTick >= Data.CooldownTicks;
    }

    public void MarkUsed(int currentTick)
    {
        LastUsedTick = currentTick;
    }
}
}