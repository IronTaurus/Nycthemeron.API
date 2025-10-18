using System.Net;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;

namespace Nycthemeron.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly GameDbContext _context;

    // Inject GameDbContext through constructor
    public ItemsController(GameDbContext context)
    {
        _context = context;
    }


    [HttpGet(Name = "GetWeapons")]
    [ProducesResponseType(typeof(IEnumerable<Talent>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<TalentDto>>> GetWeapons()
    {
        try
        {
            Console.WriteLine("Starting fetching items...");
            var weapons = await _context.Weapons
                .Include(i => i.Container)
                .Select(i => new WeaponDto
                {
                    Id = i.Id,
                    Title = i.Title,
                    Type = i.Type,
                    Damage = i.Damage,
                    Range = i.Range,
                    InitativeMod = i.InitativeMod,
                    MovementMod = i.MovementMod,
                    Grip = i.Grip,
                    WeightClass = i.WeightClass,
                    Weight = i.Weight,
                    ReloadPenalty = i.ReloadPenalty,
                    DamageTypes = i.DamageTypes,
                    Penalties = i.Penalties,
                    Effects = i.Effects

                })
                .ToListAsync();
            Console.WriteLine($"Fetched {weapons.Count} talents");
            foreach (WeaponDto w in weapons)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"ID: {w.Id}");
                Console.WriteLine($"Title: {w.Title}");
                Console.WriteLine($"Damage: {w.Damage}");
                if (w.DamageTypes != null)
                {
                    Console.WriteLine($"DamageTypes: {string.Join(", ", w.DamageTypes)}");
                }
                Console.WriteLine($"Range: {w.Range}");
                Console.WriteLine($"InitativeMod: {w.InitativeMod}");
                Console.WriteLine($"MovementMod: {w.MovementMod}");
                Console.WriteLine($"Grip: {w.Grip}");
                Console.WriteLine($"WeightClass: {w.WeightClass}");
                Console.WriteLine($"Weight: {w.Weight}");
                if (w.ReloadPenalty != null)
                {
                    Console.WriteLine($"ReloadPenalty: {string.Join(", ", w.ReloadPenalty)}");
                }
                if (w.Penalties != null)
                {
                    Console.WriteLine($"Penalties: {string.Join(", ", w.Penalties)}");
                }
                if (w.Effects != null)
                {
                    Console.WriteLine($"Effects: {string.Join(", ", w.Effects)}");
                }
            }


            return Ok(weapons);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = $"Error retrieving weapons: {ex.Message}" });
        }
    }

[HttpPost(Name = "InsertTalent")]
public async Task<IActionResult> CreateTalent([FromBody] TalentCreateDto dto)
{
    if (string.IsNullOrWhiteSpace(dto.Title))
        return BadRequest("Title is required.");

    // Map DTO to entity
    var talent = new Talent
    {
        Title = dto.Title,
        Description = dto.Description,
        Cost = dto.Cost,
        TalentTypes = dto.TalentTypes?.Select(tt => new TalentType
        {
            Name = tt.Name
        }).ToList() ?? new List<TalentType>(),
        Requirements = dto.Requirements?.Select(r => new Requirement
        {
            Attribute = r.Attribute,
            Value = r.Value
        }).ToList() ?? new List<Requirement>()
    };

    try
    {
        _context.Talents.Add(talent);
        await _context.SaveChangesAsync();

        // Map back to DTO for response
        var result = new TalentDto
        {
            Id = talent.Id,
            Title = talent.Title,
            Description = talent.Description,
            Cost = talent.Cost,
            TalentTypes = talent.TalentTypes.Select(tt => new TalentTypeDto
            {
                Id = tt.Id,
                Name = tt.Name
            }).ToList(),
            Requirements = talent.Requirements.Select(r => new RequirementDto
            {
                Id = r.Id,
                Attribute = r.Attribute,
                Value = r.Value
            }).ToList()
        };

        return CreatedAtRoute("GetTalents", new { id = talent.Id }, result);
    }
    catch (DbUpdateException ex)
    {
        return StatusCode(500, $"Error inserting talent: {ex.InnerException?.Message ?? ex.Message}");
    }
}

[HttpDelete("{id}", Name = "DeleteTalent")]
[ProducesResponseType(204)] // No Content on success
[ProducesResponseType(404)]
[ProducesResponseType(500)]
public async Task<IActionResult> DeleteTalent(int id)
{
    try
    {
        // Find talent by ID, including related entities if you want cascading delete
        var talent = await _context.Talents
            .Include(t => t.TalentTypes)
            .Include(t => t.Requirements)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (talent == null)
            return NotFound($"Talent with Id {id} not found.");

        // Remove it from the DbContext
        _context.Talents.Remove(talent);
        await _context.SaveChangesAsync();

        Console.WriteLine($"Deleted Talent with Id {id}");

        return NoContent(); // 204
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Error deleting talent: {ex.Message}");
    }
}


}

