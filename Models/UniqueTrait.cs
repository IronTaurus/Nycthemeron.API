using Nycthemeron.API.Models;

public class UniqueTrait
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    // FK
    public int RaceId { get; set; }
    public Race Race{ get; set; } = null!;


}