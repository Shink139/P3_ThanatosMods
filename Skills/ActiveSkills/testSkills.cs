using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMods;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;
using StardewValley.Monsters;
namespace P3_ThanatosMods
{
    public class TestSkills: SkillBase
    {

        public TestSkills(SkillRuntime runtime) : base(runtime)
        {
        }

        protected override bool CanUse(CompanionAI ai, Monster target)
        {
            return true;
        }

        protected override void Use(CompanionAI ai, Monster target)
        {
            // 在这里实现技能的效果
           
        }
    
        public static void Initialize()
        {
            // 在这里初始化技能
        }
    }
}