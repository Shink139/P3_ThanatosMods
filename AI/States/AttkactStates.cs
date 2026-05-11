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
    public class AttackStates:State
    {
        private readonly IMonitor _Monitor;
       
        public AttackStates(IMonitor Monitor, StateMachine sm) : base(sm)
        {
            _Monitor = Monitor;
        }
        public override void Enter(CompanionAI ai)
        {
            _Monitor.Log("进入攻击状态！", LogLevel.Info);
            // 进入攻击状态时的逻辑
        }

        public override void Update(CompanionAI ai)
    {
        var target = ai.CurrentTarget;

        // ❌ 目标没了 → 回去跟随
        if (target == null || target.Health <= 0)
        {
            stateMachine.ChangeState(new FollowStates(_Monitor, stateMachine), ai);
            return;
        }

        // 📏 判断距离
        if (!ai.InAttackRange(target))
        {
            // 👉 不够 → 追
            ai.MoveTo(target.Position);
        }
        else
        {
            // 👉 够 → 打
            ai.Attack(target);
        }
    }

        public override void Exit(CompanionAI ai)
        {
            // 退出攻击状态时的逻辑
        }
    }
}