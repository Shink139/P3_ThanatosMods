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
    public class SlashSkills: SkillBase
    {

        public SlashSkills(SkillRuntime runtime, SkillData data, AnimationController animationController) : base(runtime, data, animationController)
        {
        }

        protected override bool CanUse(CompanionAI ai, Monster target)
        {
            return true;
        }

        protected override void Use(CompanionAI ai, Monster target)
        {
            GameLocation location= ai.GetGameLocation();
            Farmer farmer=ai.GetFarmer();
            Vector2 Npcposition = ai.GetPosition();
            
            Vector2 npcPos = ai.GetPosition();
            int halfWidth = Data.HitBox.Width / 2;
            int halfHeight = Data.HitBox.Height / 2;
            Rectangle hitBox = new Rectangle(
                (int)npcPos.X - halfWidth,
                (int)npcPos.Y - halfHeight,
                Data.HitBox.Width,
                Data.HitBox.Height
            );

            location.damageMonster(
                hitBox,
                 Data.MinDamage,
                 Data.MaxDamage,
                 Data.IsBomb,
                 Data.KnockBack,
                 Data.AddedPrecision,
                 Data.CritChance,
                 Data.CritMultiplier,
                 triggerMonsterInvincibleTimer: false,
                 farmer
                 );
                 AnimationController.Play("Slash");
        }
        
    
        public static void Initialize()
        {
            // 在这里初始化技能
        }
    }
}