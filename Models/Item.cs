
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Nycthemeron.API.Models;
public abstract class Item
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    public int Weight { get; set; }   
    public string? Notes { get; set; }
    public int? InventoryId { get; set; }
    public Inventory? Inventory { get; set; }

    // Optional container reference
    public int? ContainerId { get; set; }
    public Container? Container { get; set; }

    // Equipped state
    public bool IsEquipped { get; set; } = false;
    public EquippedSlot EquippedSlot { get; set; } = EquippedSlot.None;
}