using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMods
{
    public class MapSetting
    {
        // 地图设置的相关属性和方法
        private const string MAP_NAME = "Maps/RyojiHouse";
        private const string LOCATION_NAME = "RyojiHouse";
        private const int DEFAULT_TILE_X = 6;
        private const int DEFAULT_TILE_Y = 9;


         private readonly IMonitor _Monitor;

    // 构造函数接收 IMonitor
    public MapSetting(IMonitor Monitor)
    {
        _Monitor = Monitor;
    }
             public void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            // 检查请求的素材名称是否等于你的本地地图资产名称
            if (e.NameWithoutLocale.IsEquivalentTo(MAP_NAME))
            {
                // 从你的模组文件夹读取 .tbin 文件，并将其作为 Map 素材提供给游戏
                e.LoadFromModFile<Map>("assets/Maps/RyojiHouse.tbin", AssetLoadPriority.Medium);
                this._Monitor.Log($"成功加载地图素材: {MAP_NAME}", LogLevel.Debug);
            }
        }

        public void OnSaveLoaded(object? sender, SaveLoadedEventArgs e)
        {
            // 防止因多次加载事件而重复添加
            if (Game1.locations.Any(loc => loc.Name == LOCATION_NAME))
                return;

            // 创建一个新的地点对象，关联我们上面提供的地图素材 "Maps/RyojiHouse"
            var newLocation = new GameLocation(MAP_NAME, LOCATION_NAME)
            {
                IsOutdoors = false, // 室外
                IsFarm = false
            };

            // 将这个新地点加入到游戏世界的主要地点列表中
            Game1.locations.Add(newLocation);
            this._Monitor.Log($"成功添加新地点: {LOCATION_NAME}", LogLevel.Debug);

            AddWarpToArchaeologyHouse(); 

            // 示例：为你的新地点添加一个返回考古学房子的传送门
            // 这将在地图 (9, 6) 处创建一个传送门，指向考古房子 (6, 7)
            var returnWarp = new Warp(DEFAULT_TILE_X, DEFAULT_TILE_Y, "ArchaeologyHouse", 6, 7, false, false);
            newLocation.warps.Add(returnWarp);
            this._Monitor.Log($"为地点 {LOCATION_NAME} 添加传送门至 ArchaeologyHouse (6,7)", LogLevel.Debug);

            // 你可以在这里编写为其他现有地图添加传送门的代码（例如下面的代码框架）dwd
            // AddWarpToExistingLocation("BusStop", 10, 20, LOCATION_NAME, 5, 5);
            
        }

    private void AddWarpToArchaeologyHouse()
{
    var arch = Game1.locations.FirstOrDefault(loc => loc.Name == "ArchaeologyHouse");
    if (arch == null)
    {
        this._Monitor.Log("在 Game1.locations 里没找到 ArchaeologyHouse！", LogLevel.Warn);
        return;
    }
    // 这里可以加个检查，避免重复添加同样的传送点
    if (!arch.warps.Any(w => w.X == 6 && w.Y == 6))
    {
        arch.warps.Add(new Warp(6, 6, LOCATION_NAME, 6, 9, false, false));
        this._Monitor.Log("已在考古房子 (6,7) 添加前往 RyojiHouse 的传送门", LogLevel.Info);
    }
}
    }
}