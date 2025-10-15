using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;
using System.Security.Claims;

namespace Nycthemeron.API.Controllers
{
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CharactersController : ControllerBase
{
    private readonly GameDbContext _context;

        public CharactersController(GameDbContext context)
        {
            _context = context;
        }
    
    [Authorize]
    [HttpPost("create")]
        public async Task<ActionResult<CharacterSheetDto>> CreateCharacter([FromBody] CharacterSheetCreateDto dto)
        {
        
        // Get user ID from the JWT token
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            if (userId == 0)
                return Unauthorized("Invalid user token");

            var user = await _context.Users
                .Include(u => u.Characters)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return Unauthorized("User not found");


        // Initialize character with default attributes
        var character = new CharacterSheet
        {
            UserId = userId,
            Name = dto.Name,
            BaseArmor = dto.BaseArmor,
            CurrentArmor = dto.CurrentArmor,
            MagicalArmor = dto.MagicalArmor,
            BaseSpirit = dto.BaseSpirit,
            CurrentSpirit = dto.CurrentSpirit,
            TalentPoints = dto.TalentPoints,
            Agility = new CharacterAttribute { Title = "Agility", Value = 0, Aspiration = 0 },
            Body = new CharacterAttribute { Title = "Body", Value = 0, Aspiration = 0 },
            Mind = new CharacterAttribute { Title = "Mind", Value = 0, Aspiration = 0 },
            Mystic = new CharacterAttribute { Title = "Mystic", Value = 0, Aspiration = 0 },
            Presence = new CharacterAttribute { Title = "Presence", Value = 0, Aspiration = 0 },
        };

        _context.CharacterSheets.Add(character);
        await _context.SaveChangesAsync();

        // Helper function to convert attributes to DTO
        CharacterAttributeDto ToDto(CharacterAttribute attr) => new()
        {
            Title = attr.Title,
            Value = attr.Value,
            Aspiration = attr.Aspiration
        };

        return Ok(new CharacterSheetDto
        {
            Id = character.Id,
            Name = character.Name,
            BaseArmor = character.BaseArmor,
            CurrentArmor = character.CurrentArmor,
            MagicalArmor = character.MagicalArmor,
            BaseSpirit = character.BaseSpirit,
            CurrentSpirit = character.CurrentSpirit,
            TalentPoints = character.TalentPoints,
            Agility = ToDto(character.Agility),
            Body = ToDto(character.Body),
            Mind = ToDto(character.Mind),
            Mystic = ToDto(character.Mystic),
            Presence = ToDto(character.Presence),
            Talents = new List<TalentDto>(), // empty initially
            Cards = new List<CardDto>()      // empty initially
        });
    }
}
}