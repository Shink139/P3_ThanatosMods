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
public static class SkillDatabase
{
    public static Dictionary<string, SkillData> Skills { get; private set; } = new();

    public static void Load(IModHelper helper)
    {
        List<SkillData>? list =
            helper.Data.ReadJsonFile<List<SkillData>>("assets/skills.json");

        Skills = list?.ToDictionary(skill => skill.Id)
                 ?? new Dictionary<string, SkillData>();
    }

    public static SkillData Get(string id)
    {
        if (Skills.TryGetValue(id, out SkillData? data))
        {
            return data;
        }
    throw new Exception($"SkillData not found: {id}");
    }
}}