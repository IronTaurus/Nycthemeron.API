namespace Nycthemeron.API.Models;

public class Modifier
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public int Value { get; set; }
    public string Condition { get; set; } = null!;
    public string Description { get; set; } = null!;
}