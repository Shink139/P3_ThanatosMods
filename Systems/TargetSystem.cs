using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMods;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Monsters;

namespace P3_ThanatosMods
{
    public class TargetSystem
    {
        private readonly IMonitor _Monitor;
        private CompanionAI ai;
        private float searchRadius = 500f;

        public TargetSystem(IMonitor Monitor, CompanionAI ai)
        {
            _Monitor = Monitor;
            this.ai = ai;
        }
        public Monster FindNearestEnemy()
    {
        var location = ai.npc_P?.currentLocation;
        Monster? nearest = null;
        float minDist = float.MaxValue;

        if (location == null) return null;

        foreach (var character in location.characters)
        {
            if (character is Monster monster)
            {
                float dist = Vector2.Distance(ai.npc_P?.Position ?? Vector2.Zero, monster.Position);

                if (dist < searchRadius && dist < minDist)
                {
                    minDist = dist;
                    nearest = monster;
                }
            }
        }

        return nearest;
    }
    }
}