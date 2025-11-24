namespace Nycthemeron.API.Models;

public class RacialTrait
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Type { get; set; }
    public List<CharacterSheet> Characters { get; set; } = new(); // many-to-many
}