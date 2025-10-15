namespace Nycthemeron.API.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string? Attribute { get; set; }
        public int Value { get; set; }

        // FK → Talent
        public int TalentId { get; set; }
        public Talent? Talent { get; set; }
    }
}