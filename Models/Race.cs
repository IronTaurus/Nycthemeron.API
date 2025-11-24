namespace Nycthemeron.API.Models;
using System.ComponentModel.DataAnnotations;

public class Race
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
    public string? RacialFamily { get; set; }        
    public int AgeExpectancy { get; set; }
    public string? Size { get; set; }
    public int EncumbermentLimit { get; set; }
    public string? Background { get; set; }
    public string? Appearence { get; set; }
    public string? Behaviour { get; set; }
    public List<UniqueTrait>? UniqueTraits { get; set; } = new();
    public List<CharacterAttribute> Attributes { get; set; } = new();
    public List<RacialTrait> PositiveRacialTraits { get; set; } = new();
    public List<RacialTrait> NegativeRacialTraits { get; set; } = new();
    public List<Talent> ChooseableTalents { get; set; } = new();
}

public class UniqueTrait
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    // FK
    public int RaceId { get; set; }
    public Race Race { get; set; } = null!;


}