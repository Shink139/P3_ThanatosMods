using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMod;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMods
{
    public class AIManager
    {
        private readonly IMonitor _Monitor;

        private Dictionary<string,CompanionAI> controllers = new();
       
      
     private bool isInCombat = false;

        public AIManager(IMonitor monitor)
        {
            _Monitor = monitor;
        }
        public void Initialize(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += Update;
            helper.Events.Player.Warped += OnWarped;
        }
        public void Update(object? sender, EventArgs e)
        {
            if (!Context.IsWorldReady) return;
            foreach (var controller in controllers.Values)
            {
                controller.Update();
            }
        }
        public void OnWarped(object? sender, WarpedEventArgs e)
        {
             if (!e.IsLocalPlayer) return;

         // 判断是否进入了矿井内部（普通矿井和骷髅洞穴内部地图名都是 "UndergroundMine"）
            bool isMineShaft = e.NewLocation is MineShaft;
        // 如果是 MineShaft，获取层数；否则为 -1
            int mineLevel = isMineShaft ? ((MineShaft)e.NewLocation).mineLevel : -1;
            if (isMineShaft && mineLevel > 1)
            {
                foreach (var controller in controllers.Values)
            {
                controller.ExistNPC(e.NewLocation);
            }
            }


        }
    

        public void Add(CompanionAI companion)
        {
            controllers[companion.NPCName] = companion;
        }
        public void Remove(string npcName)
        {
            controllers.Remove(npcName);
        }


        
}}