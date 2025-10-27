namespace Nycthemeron.API.Models
{
    public class CardDto
    {
        public int Id { get; set; }
        public string? MainClass { get; set; }
        public string? SubClass { get; set; }
        public string? Tier { get; set; }
        public int Charges { get; set; }
        
        //Sun
        public string? SunTitle { get; set; }
        public List<string> SunActionTypes { get; set; } = new();
        public string? SunAbilityType { get; set; }
        public int SunSpiritCost { get; set; }
        public string? SunRuleText { get; set; }
        public string? SunRequirements { get; set; }

        //Moon
        public string? MoonTitle { get; set; }
        public List<string> MoonActionTypes { get; set; } = new();
        public string? MoonAbilityType { get; set; }
        public int MoonSpiritCost { get; set; }
        public string? MoonRuleText { get; set; }
        public string? MoonRequirements { get; set; }
    }
}