public class WeaponDto : ItemDto
{
    public string? Type { get; set; }
    public int Damage { get; set; }
    public int Range { get; set; }
    public int InitativeMod { get; set; }
    public int MovementMod { get; set; }
    public string? Grip { get; set; }
    public string? WeightClass { get; set; }

    public List<string>? ReloadPenalty { get; set; }
    public List<string>? DamageTypes { get; set; }
    public List<string>? Penalties { get; set; }
    public List<string>? Effects { get; set; }
}