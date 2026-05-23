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
    public abstract class SkillBase
    {
       protected readonly SkillRuntime Runtime;
       protected SkillData Data;
       protected AnimationController AnimationController;

    public SkillBase(SkillRuntime runtime, SkillData data, AnimationController animationController)
    {
        Runtime = runtime;
        Data = data;
        AnimationController = animationController;
    }

    public bool TryUse(CompanionAI ai, Monster target, int currentTick)
    {
        if (!Runtime.IsReady(currentTick))
            return false;

        if (!CanUse(ai, target))
            return false;

        Use(ai, target);
        Runtime.MarkUsed(currentTick);
        return true;
    }

    protected abstract bool CanUse(CompanionAI ai, Monster target);
    protected abstract void Use(CompanionAI ai, Monster target);
    }
    }