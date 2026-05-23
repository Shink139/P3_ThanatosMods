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
public static class SkillFactory
{
    public static SkillBase Create(string skillId, AnimationController animationController)
    {
        SkillData data = SkillDatabase.Get(skillId);
        SkillRuntime runtime = new SkillRuntime(data);

        return data.SkillType switch
        {
            "Slash" => new SlashSkills(runtime, data, animationController),
            //"Fireball" => new FireballSkill(runtime),
            _ => throw new Exception($"Unknown SkillType: {data.SkillType}")
        };
    }
    }}