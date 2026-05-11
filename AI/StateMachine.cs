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
    public class StateMachine
    {
        private State?currentState;
        public StateMachine(IMonitor Monitor)
        {
            currentState = new FollowStates(Monitor, this);
        }

    public void ChangeState(State newState, CompanionAI ai)
    {
        currentState?.Exit(ai);
        newState.Update(ai);
        currentState = newState;
    }

    public void Update(CompanionAI ai)
    {
        currentState?.Update(ai);
    }
    }}