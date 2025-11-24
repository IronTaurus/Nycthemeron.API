using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;

namespace Nycthemeron.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RaceController : ControllerBase
{
    private readonly GameDbContext _context;

    public RaceController(GameDbContext context)
    {
        _context = context;
    }


    [HttpGet(Name = "GetRaces")]
    [ProducesResponseType(typeof(IEnumerable<Talent>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<TalentDto>>> GetRaces()
    {
        try
        {
            Console.WriteLine("Starting fetching races...");
            var races = await _context.Races
                .Include(r => r.ChooseableTalents)
                .Include(r => r.PositiveRacialTraits)
                .Include(r => r.NegativeRacialTraits)
                .Include(r => r.UniqueTraits)
                .Select(r => new RaceDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Key = r.Key,
                    RacialFamily = r.RacialFamily,
                    AgeExpectancy = r.AgeExpectancy,
                    Size = r.Size,
                    EncumbermentLimit = r.EncumbermentLimit,
                    Background = r.Background,
                    Appearence = r.Appearence,
                    Behaviour = r.Behaviour,

                    UniqueTraits = r.UniqueTraits
                        .Select(u => new UniqueTraitDto {Id = u.Id, Title = u.Title, Description = u.Description})
                        .ToList(),
                    PositiveRacialTraits = r.PositiveRacialTraits
                        .Select(r => new RacialTraitDto {Id = r.Id, Title = r.Title, Description = r.Description})
                        .ToList(),
                    NegativeRacialTraits = r.NegativeRacialTraits
                        .Select(r => new RacialTraitDto { Id = r.Id, Title = r.Title, Description = r.Description })
                        .ToList()
                })
                .ToListAsync();
            Console.WriteLine($"Fetched {races.Count} races");
            return Ok(races);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = $"Error retrieving races: {ex.Message}" });
        }
    }
}