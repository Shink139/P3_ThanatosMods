using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;
using xTile.Dimensions;

namespace P3_ThanatosMods
{
    public class TransformSystem{
     private readonly IMonitor _Monitor;
     private readonly NPCManager _NPCManager;
     private AIManager _AIManager;
     private bool isInCombat = false;
     private string NPCname_R = "Ryoji";
     private string NPCname_P = "Thanatos";
     private NPC? npc_R;
     private NPC? npc_P;
     
     Dictionary<string,NPC>cachedNPCs=new Dictionary<string,NPC>();
    // 构造函数接收 IMonitor 和 NPCManager
    public TransformSystem(IMonitor Monitor, NPCManager NPCManager, AIManager AIManager)
    {
        _Monitor = Monitor;
        _NPCManager = NPCManager;
        _AIManager = AIManager;
    }

    public void OnWarped(object? sender, WarpedEventArgs e)
{
    if(npc_P==null||npc_R==null)
    {
        npc_R = Game1.getCharacterFromName(NPCname_R,false);
        npc_P = Game1.getCharacterFromName(NPCname_P,false);
    }
    if (!e.IsLocalPlayer) return;

    // 判断是否进入了矿井内部（普通矿井和骷髅洞穴内部地图名都是 "UndergroundMine"）
    bool isMineShaft = e.NewLocation is MineShaft;
    // 如果是 MineShaft，获取层数；否则为 -1
    int mineLevel = isMineShaft ? ((MineShaft)e.NewLocation).mineLevel : -1;

    // 情况一：进入矿洞第一层
    if (isMineShaft && mineLevel == 1)
    {
        _Monitor.Log("进入矿洞第一层！", LogLevel.Info);
        Transform(e.NewLocation);
        _NPCManager.SetNPCPosition(npc_P,e.NewLocation);
        isInCombat = true;   
        CompanionAI companion = new CompanionAI(_Monitor, npc_P);
        _AIManager.Add(companion);
    }
    else if (isInCombat && !isMineShaft)
    {
        _Monitor.Log("离开矿洞！", LogLevel.Info);
        TransformBack(e.NewLocation);
        isInCombat = false;
        _AIManager.Remove(NPCname_P);
    }
}

    public void Transform(GameLocation newLocation)
        {
            // Implement transformation logic here
            if (npc_R != null)
            {
                TransToCombat(npc_R, newLocation);
                _Monitor.Log($"变身为战斗形态：{npc_R.Name}");
            }
            else
            {
                _Monitor.Log("未找到NPC_R，无法变身！", LogLevel.Warn);
            }
            isInCombat = true;
        }

        public void TransformBack(GameLocation newLocation)
        {
            // Implement transformation back logic here
            if (npc_P != null)
            {
                TransToNormal(npc_P, newLocation);
                _Monitor.Log($"变身为普通形态：{npc_P.Name}");
            }else
            {
                _Monitor.Log("未找到NPC_P，无法变身回普通形态！", LogLevel.Warn);
            }
            isInCombat = false;
        }

        public void WarpLevelChange(GameLocation newLocation)
        {
            DelayedAction.functionAfterDelay(() =>
            {
                if (npc_P == null) return;
            npc_P.currentLocation = newLocation;
    
            if (!newLocation.characters.Contains(npc_P))
            {
                _NPCManager.Add(npc_P, newLocation);
            }

            _NPCManager.SetNPCPosition(npc_P,newLocation);
            }
            , 200); // 延迟200毫秒执行，以确保玩家已经完全进入新地图
        }

    private void TransToCombat(NPC npc_R,GameLocation newLocation)
        {
            cachedNPCs[npc_R.Name] = npc_R;
            _NPCManager.Tofreeze(npc_R);
            NPC npc_P = Game1.getCharacterFromName(NPCname_P);
            _NPCManager.Add(npc_P,newLocation);
            _NPCManager.SetNPCPosition(npc_P,newLocation);
        }
        private void TransToNormal(NPC npc_P,GameLocation newLocation)
        {   
             _NPCManager.Remove(npc_P,newLocation);
             var npc = cachedNPCs[NPCname_R];
            _NPCManager.Backfreeze(npc);
            npc_P.IsInvisible = true;

    }

    
}}