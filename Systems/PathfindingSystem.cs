using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMods
{
    public class PathfindingSystem
    {
        private readonly IMonitor _Monitor;
        private CompanionAI ai;
            private const float speed = 4f; // 移动速度，可以根据需要调整

        public PathfindingSystem(IMonitor Monitor, CompanionAI ai)
        {
            _Monitor = Monitor;
            this.ai = ai;
        }
public void MoveTo(Vector2 target)
    {
        Vector2 current = ai.npc_P?.Position ?? Vector2.Zero;
        Vector2 direction = target - current;

        if (direction.Length() < 1f) return;

        direction.Normalize();

        Vector2 newPos = current + direction * speed;

        ai.npc_P.Position = newPos;
    }

    public void Stop()
    {
        // 可以留空，或者清状态
    }
    }
}