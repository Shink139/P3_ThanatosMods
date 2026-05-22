using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using P3_ThanatosMod;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;
using StardewValley.Monsters;

namespace P3_ThanatosMods
{
    public  class SkillManager
    {
        static List<SkillBase> skills = new List<SkillBase>();
         public IReadOnlyList<SkillBase> Skills => skills;

         public SkillManager(List<string> skillIds)
        {
            foreach (string id in skillIds)
            {
            SkillBase skill = SkillFactory.Create(id);
            skills.Add(skill);
            }
        }
        public static bool TryUseBestSkill(CompanionAI ai, Monster target)
        {
            // 在这里实现选择和使用最佳技能的逻辑
            int currentTick = Game1.ticks;

        foreach (SkillBase skill in skills)
        {
            if (skill.TryUse(ai, target, currentTick))
                return true;
        }

        return false;
        }
    }
}