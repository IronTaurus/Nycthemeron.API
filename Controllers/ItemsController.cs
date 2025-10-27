using System.Net;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
}

