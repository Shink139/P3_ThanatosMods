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
    public class NPCManager
    {
        private readonly IMonitor _Monitor;

        // 构造函数接收 IMonitor
        public NPCManager(IMonitor Monitor)
        {
            _Monitor = Monitor;
        }
        public void Remove(NPC npc,GameLocation newLocation)
        {
            newLocation.characters.Remove(npc);
            _Monitor.Log($"NPC {npc.Name} 已被移除。", LogLevel.Info);
    }

    public void Add(NPC npc,GameLocation newLocation)
    {
        newLocation.characters.Add(npc);
        _Monitor.Log($"NPC {npc.Name} 已被添加。", LogLevel.Info);
    }

    public void Tofreeze(NPC npc)
        {
            npc.controller=null;
            npc.Halt();
            npc.SetMovingUp(false);
            npc.SetMovingDown(false);
            npc.SetMovingLeft(false);
            npc.SetMovingRight(false);
            npc.Speed=0;
            npc.IsInvisible=true;
        }
        public void Backfreeze(NPC npc)
        {
            npc.IsInvisible=false;
            npc.Halt();
        }
        public void SetNPCPosition(NPC npc, GameLocation location)
    {
        Vector2 npcTile = GetNPCPosition(location);
        npc.setTileLocation(npcTile);
         npc.controller=null;
            npc.Halt();
    }

    public Vector2 GetNPCPosition(GameLocation location)
    {
        // 获取玩家当前的瓦片位置
        Vector2 playerTile = new Vector2((int)(Game1.player.Position.X / 64f), (int)(Game1.player.Position.Y / 64f));
        // 计算NPC应该出现的位置（例如，玩家前方一个瓦片）
        Vector2 npcTile = new Vector2(playerTile.X, playerTile.Y -1); // 玩家前方一个瓦片
        return npcTile;
}
}
}