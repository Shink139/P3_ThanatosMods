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

public class SkillData
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";

    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    public int CooldownTicks { get; set; }
    public int Range { get; set; }
    public int Priority { get; set; }

    public float KnockBack { get; set; }
    public float CritChance { get; set; }
    public float CritMultiplier { get; set; }

    public bool IsProjectile { get; set; }
    public bool IsBomb { get; set; }

    public string SkillType { get; set; } = "";
}}