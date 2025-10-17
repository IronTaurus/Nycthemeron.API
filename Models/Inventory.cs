using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Nycthemeron.API.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        // Reference back to character
        public int CharacterSheetId { get; set; }
        public CharacterSheet CharacterSheet { get; set; } = null!;
        public List<Item>? Items { get; set; } = new();



  // Equipped slots
        public int? MainHandId { get; set; }
        public Weapon? MainHand { get; set; }

        public int? OffHandId { get; set; }
        public Weapon? OffHand { get; set; }

        public int? EquippedArmorId { get; set; }
        public Armor? EquippedArmor { get; set; }
    }
}