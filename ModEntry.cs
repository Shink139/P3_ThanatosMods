using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMods  
{
    public class ModEntry : Mod
    {
        private MapSetting? _mineHandler;
        private AIManager? _AIManager;
        private TransformSystem? _transformHandler;
        private NPCManager? _NPCManager;
        
        public override void Entry(IModHelper helper)
        {
             SkillDatabase.Load(helper);
            NPCDatabase.Load(helper);
            AnimationDatabase.Load(helper);
            Monitor.Log("当前DLL版本：2026-05-23-TEST-001", LogLevel.Warn);

            _mineHandler = new MapSetting(this.Monitor);
            _NPCManager = new NPCManager(this.Monitor);
             _AIManager = new AIManager(this.Monitor);
            _transformHandler = new TransformSystem(this.Monitor, _NPCManager, _AIManager);
           
            //地图设置
           // helper.Events.Content.AssetRequested += _mineHandler.OnAssetRequested;
            //helper.Events.GameLoop.SaveLoaded += _mineHandler.OnSaveLoaded;
          
            //变身系统设置
            helper.Events.Player.Warped += _transformHandler.OnWarped;
           _AIManager.Initialize(this.Helper);

           
        }

       
    }
}