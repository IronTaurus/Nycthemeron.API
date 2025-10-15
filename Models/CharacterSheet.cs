namespace Nycthemeron.API.Models
{
    public class CharacterSheet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int AgilityId { get; set; }
        public CharacterAttribute Agility { get; set; }  = new() {Title = "Agility", Value = 0, Aspiration = 0};

        public int BodyId { get; set; }
        public CharacterAttribute Body { get; set; }  = new() {Title = "Body", Value = 0, Aspiration = 0};

        public int MindId { get; set; }
        public CharacterAttribute Mind { get; set; }  = new() {Title = "Mind", Value = 0, Aspiration = 0};

        public int MysticId { get; set; }
        public CharacterAttribute Mystic { get; set; }  = new() {Title = "Mystic", Value = 0, Aspiration = 0};

        public int PresenceId { get; set; }
        public CharacterAttribute Presence { get; set; }  = new() {Title = "Presence", Value = 0, Aspiration = 0};

        public int BaseArmor { get; set; }
        public int CurrentArmor { get; set; }
        public int MagicalArmor { get; set; }
        public int BaseSpirit { get; set; }
        public int CurrentSpirit { get; set; }
        public int TalentPoints { get; set; }

        // Relations
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public Inventory Inventory { get; set; } = new();
        public List<Talent> Talents { get; set; } = new();
        public List<Card>? Cards { get; set; } = new();

    }
}