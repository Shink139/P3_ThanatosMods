using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMod;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Monsters;
using xTile;

namespace P3_ThanatosMods
{
    public class CompanionAI
    {
            private readonly IMonitor _Monitor;
            public string NPCName="Thanatos";
            public Monster? CurrentTarget;
            public NPC? npc_P;
            public Farmer? player_P => Game1.player;
            private readonly NPCManager _NPCManager;

            public TargetSystem TargetSystem { get; }
            public NPCData Data { get; }
            public SkillManager SkillManager { get; }
            public PathfindingSystem PathfindingSystem { get; }
            public CombatSystem CombatSystem { get; }
            private StateMachine stateMachine;
            private AnimationController animationController;
          
            // 构造函数接收 IMonitor 和 NPCManager
            public CompanionAI(IMonitor Monitor,NPC npc,NPCData npcData)
            {
                _Monitor = Monitor;
                animationController = new AnimationController(npc);
                npc_P = npc;
                _NPCManager = new NPCManager(Monitor);
                    TargetSystem = new TargetSystem(Monitor, this);
                    PathfindingSystem = new PathfindingSystem(Monitor, this);
                    CombatSystem = new CombatSystem(Monitor, this);
                     Data = npcData;
               
                stateMachine = new StateMachine(Monitor);
                 SkillManager = new SkillManager(npcData.Skills, animationController, _Monitor);
            }
            public void Update()
        {
            stateMachine.Update(this);
             animationController.Update();
        }


        public void ExistNPC(GameLocation newLocation)
        {
            if (npc_P == null) return;
                DelayedAction.functionAfterDelay(() =>
            {
                if (npc_P == null) return;
            npc_P.currentLocation = newLocation;
    
            if (!newLocation.characters.Contains(npc_P))
            {
                _NPCManager.Add(npc_P, newLocation);
            }
            _NPCManager.SetNPCPosition(npc_P,newLocation);
            stateMachine.ChangeState(new FollowStates(_Monitor, stateMachine), this);
            }
            
            , 200); // 延迟200毫秒执行，以确保玩家已经完全进入新地图
                
            
        }
        public void MoveTo(Vector2 target)
{
    PathfindingSystem.MoveTo(target);
}

public void StopMoving()
{
    PathfindingSystem.Stop();
}

public Monster GetTarget()
{
    CurrentTarget = TargetSystem.FindNearestEnemy();
    return CurrentTarget;
}

public bool InAttackRange(Monster target)
{
    return Vector2.Distance(npc_P?.Position ?? Vector2.Zero, target.Position) < 300f;
}

public void Attack(Monster target)
{
    SkillManager.TryUseBestSkill(this, target);
    //CombatSystem.Attack(target);
}
public GameLocation GetGameLocation()
        {
            return npc_P?.currentLocation;
        }
public Farmer GetFarmer()
        {
            return player_P;
        }
public Vector2 GetPosition()
        {
            return npc_P?.Position ?? Vector2.Zero;
        }
}}