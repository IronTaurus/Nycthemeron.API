public class RacialTraitDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}

public class RacialTraitCreateDto
{
    public string? Title { get; set; } = null!;
    public string? Description { get; set; }
}