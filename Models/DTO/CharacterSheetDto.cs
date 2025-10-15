using System.Text.Json.Serialization;

namespace Nycthemeron.API.Models
{
    public class CharacterSheetDto
    {
        public int Id { get; set; }  // CharacterSheet Id
        public string? Name { get; set; }
        public int BaseArmor { get; set; }
        public int CurrentArmor { get; set; }
        public int MagicalArmor { get; set; }
        public int BaseSpirit { get; set; }
        public int CurrentSpirit { get; set; }
        public int TalentPoints { get; set; }

        public CharacterAttributeDto Agility { get; set; } = new();
        public CharacterAttributeDto Body { get; set; } = new();
        public CharacterAttributeDto Mind { get; set; } = new();
        public CharacterAttributeDto Mystic { get; set; } = new();
        public CharacterAttributeDto Presence { get; set; } = new();
        public List<TalentDto> Talents { get; set; } = new();
        public List<CardDto> Cards { get; set; } = new();

        [JsonIgnore]
        public List<CharacterAttributeDto> Attributes => new() { Agility, Body, Mind, Mystic, Presence };
    }
    
        public class CharacterSheetCreateDto
    {
        public string? Name { get; set; }
        public CharacterAttributeDto Agility { get; set; }
        public CharacterAttributeDto Body { get; set; }
        public CharacterAttributeDto Mind { get; set; }
        public CharacterAttributeDto Mystic { get; set; }
        public CharacterAttributeDto Presence { get; set; }

        public int BaseArmor { get; set; }
        public int CurrentArmor { get; set; }
        public int MagicalArmor { get; set; }
        public int BaseSpirit { get; set; }
        public int CurrentSpirit { get; set; }
        public int TalentPoints { get; set; }
    }
}