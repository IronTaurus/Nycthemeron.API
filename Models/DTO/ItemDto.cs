using Nycthemeron.API.Models;

public abstract class ItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Weight { get; set; }
    public string? Notes { get; set; }
    public bool IsEquipped { get; set; }
    public EquippedSlot EquippedSlot { get; set; }

    public string ItemType { get; set; } = null!; // “Weapon”, “Armor”, etc.
}