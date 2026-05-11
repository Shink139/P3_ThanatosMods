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
    public abstract class State
    {
         protected StateMachine stateMachine;

        public State(StateMachine sm)
        {
            stateMachine = sm;
        }

    public virtual void Enter(CompanionAI ai) {}
    public virtual void Exit(CompanionAI ai) {}

    public abstract void Update(CompanionAI ai);
    }
}