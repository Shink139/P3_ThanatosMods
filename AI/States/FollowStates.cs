using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;
using P3_ThanatosMods;

namespace P3_ThanatosMod
{
    public class FollowStates:State
    {
        private readonly IMonitor _Monitor;
         private const float FollowDistance = 150f;
        public FollowStates(IMonitor Monitor, StateMachine sm) : base(sm)
        {
            _Monitor = Monitor;
        }
        public override void Enter(CompanionAI ai)
        {
           // _Monitor.Log("进入跟随状态！", LogLevel.Info);

            // 进入跟随状态时的逻辑
        }
        public override void Update(CompanionAI ai)
        {
            float distance = Vector2.Distance(ai.npc_P?.Position ?? Vector2.Zero, ai.player_P?.Position ?? Vector2.Zero);

        // 判断：离太远才跟
        if (distance > FollowDistance)
        {
            ai.MoveTo(ai.player_P?.Position ?? Vector2.Zero);
        }
            var target = ai.GetTarget();

            if (target != null)
         {
            ai.CurrentTarget = target;
              stateMachine.ChangeState(new AttackStates(_Monitor,stateMachine), ai);
                 }
            }

        
        public override void Exit(CompanionAI ai)
        {
           // _Monitor.Log("退出跟随状态！", LogLevel.Info);
            // 退出跟随状态时的逻辑
        }
    }
}