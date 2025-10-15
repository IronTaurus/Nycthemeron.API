public class TalentDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Cost { get; set; }
    public List<TalentTypeDto> TalentTypes { get; set; } = new();
    public List<RequirementDto> Requirements { get; set; } = new();
}

public class TalentTypeDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class RequirementDto
{
    public int Id { get; set; }
    public string? Attribute { get; set; }
    public int Value { get; set; }
}

public class TalentCreateDto
{
    public string? Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Cost { get; set; }
    public List<TalentTypeDto> TalentTypes { get; set; } = new();
    public List<RequirementDto> Requirements { get; set; } = new();
}