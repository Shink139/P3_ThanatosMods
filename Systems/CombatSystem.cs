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
    public class CombatSystem
    {
        private readonly IMonitor _Monitor;
        private CompanionAI ai;
         private int damage = 100;

        public CombatSystem(IMonitor Monitor, CompanionAI ai)
        {
            _Monitor = Monitor;
            this.ai = ai;
        }
        public void Attack(Monster target)
    {
        GameLocation location= ai.GetGameLocation();
        Farmer farmer=ai.GetFarmer();
        // 生成掉落物品，落在怪物站立位置
        
       location.damageMonster(target.GetBoundingBox(), damage, damage + 1, isBomb: false, 0f, 0, 0f, 0f, triggerMonsterInvincibleTimer: false,farmer);
    
        target.getExtraDropItems();
        
        
    }
    }
}