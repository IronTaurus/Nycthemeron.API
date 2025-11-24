namespace Nycthemeron.API.Models;

public class Talent
{
    public int Id { get; set; }
    public string? Key { get; set; }
    
    
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Cost { get; set; }

    public List<TalentType> TalentTypes { get; set; } = new();
    public List<Requirement> Requirements { get; set; } = new();

    public List<CharacterSheet> Characters { get; set; } = new(); // many-to-many
    public List<Race> Races { get; set; } = new(); // many-to-many
}