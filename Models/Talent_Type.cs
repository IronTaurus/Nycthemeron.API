namespace Nycthemeron.API.Models
{
    public class TalentType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // FK → Talent
        public int TalentId { get; set; }
        public Talent? Talent { get; set; }
    }
}