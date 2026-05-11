using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMod;
using P3_ThanatosMods;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMod
{
    public class IdleStates:State
    {
        private readonly IMonitor _Monitor;
        public IdleStates(IMonitor Monitor,StateMachine sm) : base(sm)
        {
            _Monitor = Monitor;
        }
        public override void Enter(CompanionAI ai)
        {
            _Monitor.Log("进入空闲状态！", LogLevel.Info);
            // 进入空闲状态时的逻辑
        }

        public override void Update(CompanionAI ai)
        {
            // 空闲状态中的逻辑
        }

        public override void Exit(CompanionAI ai)
        {
            _Monitor.Log("退出空闲状态！", LogLevel.Info);
            // 退出空闲状态时的逻辑
        }
    }
}