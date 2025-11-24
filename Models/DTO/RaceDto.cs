namespace Nycthemeron.API.Models;
using System.ComponentModel.DataAnnotations;

public class RaceDto
{
    public int Id { get; set; }
    public string? Key { get; set; } 
    public string Name { get; set; } = null!;
    public string? RacialFamily { get; set; }
    public int AgeExpectancy { get; set; }
    public string? Size { get; set; }
    public int EncumbermentLimit { get; set; }
    public string? Background { get; set; }
    public string? Appearence { get; set; }
    public string? Behaviour { get; set; }   
    public List<UniqueTraitDto>? UniqueTraits { get; set; } = new();
    public List<CharacterAttributeDto> Attributes { get; set; } = new();
    public List<RacialTraitDto> PositiveRacialTraits { get; set; } = new();
    public List<RacialTraitDto> NegativeRacialTraits { get; set; } = new();
    public List<TalentDto> ChooseableTalents { get; set; } = new();

}

public class RaceCreateDto
{
    public string? Key { get; set; }
    public string Name { get; set; } = null!;
    public string? RacialFamily { get; set; }
    public int AgeExpectancy { get; set; }
    public string? Size { get; set; }
    public int EncumbermentLimit { get; set; }
    public string? Background { get; set; }
    public string? Appearence { get; set; }
    public string? Behaviour { get; set; }
    public List<UniqueTraitDto> UniqueTraits { get; set; } = new();
    public List<CharacterAttributeDto> Attributes { get; set; } = new();
    public List<RacialTraitDto> PositiveRacialTraits { get; set; } = new();
    public List<RacialTraitDto> NegativeRacialTraits { get; set; } = new();
    public List<TalentDto> ChooseableTalents { get; set; } = new();
}