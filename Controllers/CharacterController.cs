using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;


namespace Nycthemeron.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CharactersController : ControllerBase
    {
        private readonly GameDbContext _context;

        public CharactersController(GameDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterSheetDto>>> GetCharacters()
        {
            try
            {
                System.Console.WriteLine("´Starting fetching Characters...");
                System.Console.WriteLine("Getting user ID...");             
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
                if (userId == 0)
                    return Unauthorized("Invalid user token");

                // Check if the logged-in user is an Admin
                var isAdmin = User.IsInRole("Admin");

                System.Console.WriteLine(isAdmin
                    ? "Admin access granted — fetching all characters..."
                    : $"User access granted — fetching characters for user ID: {userId}");

                var charactersQuery = _context.CharacterSheets
                    .Include(c => c.Cards)
                    .Include(c => c.Talents)
                    .Include(c => c.Inventory)
                        .ThenInclude(i => i.Items);

                var characters = isAdmin
                    ? await charactersQuery.ToListAsync() // Admin gets full access
                    : await charactersQuery.Where(c => c.UserId == userId).ToListAsync();

                System.Console.WriteLine("Fetching Characters...");
                CharacterAttributeDto ToDto(CharacterAttribute attr)
                {
                    return new CharacterAttributeDto
                    {
                        Title = attr.Title,
                        Value = attr.Value,
                        Aspiration = attr.Aspiration
                    };
                }

                ItemDto MapItemToDto(Item i) => i switch
                {
                    Weapon w => new WeaponDto
                    {
                        Id = w.Id,
                        Title = w.Title,
                        Notes = w.Notes,
                        IsEquipped = w.IsEquipped,
                        EquippedSlot = w.EquippedSlot,
                        ItemType = "Weapon",
                        Type = w.Type,
                        Damage = w.Damage,
                        Range = w.Range,
                        InitativeMod = w.InitativeMod,
                        MovementMod = w.MovementMod,
                        Grip = w.Grip,
                        WeightClass = w.WeightClass,
                        ReloadPenalty = w.ReloadPenalty,
                        DamageTypes = w.DamageTypes,
                        Penalties = w.Penalties,
                        Effects = w.Effects
                    },
                    Armor a => new ArmorDto
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Notes = a.Notes,
                        IsEquipped = a.IsEquipped,
                        EquippedSlot = a.EquippedSlot,
                        ItemType = "Armor",
                        ArmorValue = a.ArmorValue,
                        Initative = a.Initative,
                        Resistances = a.Resistances,
                        Penalties = a.Penalties,
                        Effects = a.Effects
                    },
                    Other o => new OtherDto
                    {
                        Id = o.Id,
                        Title = o.Title,
                        Notes = o.Notes,
                        IsEquipped = o.IsEquipped,
                        EquippedSlot = o.EquippedSlot,
                        ItemType = "Other",
                        Quantity = o.Quantity
                    },
                    Container c => new ContainerDto
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Notes = c.Notes,
                        IsEquipped = c.IsEquipped,
                        EquippedSlot = c.EquippedSlot,
                        ItemType = "Container",
                        ContainedItems = c.ContainingItems?.Select(MapItemToDto).ToList() ?? new List<ItemDto>()
                    },
                    Accessory ac => new AccessoryDto
                    {
                        Id = ac.Id,
                        Title = ac.Title,
                        Notes = ac.Notes,
                        IsEquipped = ac.IsEquipped,
                        EquippedSlot = ac.EquippedSlot,
                        ItemType = "Accessory",
                        Effects = ac.Effects
                    },
                    _ => throw new InvalidOperationException($"Unknown item type: {i.GetType().Name}")
                };

                var characterDtos = characters.Select(c => new CharacterSheetDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age,
                    Race = c.Race,
                    Sex = c.Sex,
                    MaxHitpoints = c.MaxHitpoints,
                    CurrentHitpoints = c.CurrentHitpoints,
                    TempHitpoints = c.TempHitpoints,
                    BaseArmor = c.BaseArmor,
                    CurrentArmor = c.CurrentArmor,
                    MagicalArmor = c.MagicalArmor,
                    BaseSpirit = c.BaseSpirit,
                    CurrentSpirit = c.CurrentSpirit,
                    TalentPoints = c.TalentPoints,
                    Agility = ToDto(c.Agility),
                    Body = ToDto(c.Body),
                    Mind = ToDto(c.Mind),
                    Mystic = ToDto(c.Mystic),
                    Presence = ToDto(c.Presence),
                    Talents = c.Talents.Select(t => new TalentDto
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Cost = t.Cost,
                        Description = t.Description
                    }).ToList(),
                    Cards = c.Cards?.Select(card => new CardDto
                    {
                        Id = card.Id,
                        MainClass = card.MainClass,
                        SubClass = card.SubClass,
                        Tier = card.Tier,
                        Charges = card.Charges,
                        SunTitle = card.SunTitle,
                        SunAbilityType = card.SunAbilityType,
                        SunActionTypes = card.SunActionTypes,
                        SunRequirements = card.SunRequirements,
                        SunRuleText = card.SunRuleText,
                        SunSpiritCost = card.SunSpiritCost,
                        MoonTitle = card.MoonTitle,
                        MoonAbilityType = card.MoonAbilityType,
                        MoonActionTypes = card.MoonActionTypes,
                        MoonRequirements = card.MoonRequirements,
                        MoonRuleText = card.MoonRuleText,
                        MoonSpiritCost = card.MoonSpiritCost
                        // add other card properties here
                    }).ToList() ?? new List<CardDto>(),
                    Inventory = new InventoryDto
                    {
                        Id = c.Inventory.Id,
                        Items = c.Inventory.Items?.Select(MapItemToDto).ToList() ?? new List<ItemDto>(),
                        MainHandId = c.Inventory.MainHandId,
                        OffHandId = c.Inventory.OffHandId,
                        EquippedArmorId = c.Inventory.EquippedArmorId
                    }
                }).ToList();

                return Ok(characterDtos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

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

            var inventory = new Inventory();

            // Create a character with default attributes
            var character = new CharacterSheet
            {
                UserId = userId,
                Name = dto.Name,
                Age = dto.Age,
                Race = dto.Race,
                Sex = dto.Sex,
                MaxHitpoints = dto.MaxHitpoints,
                CurrentHitpoints = dto.CurrentHitpoints,
                TempHitpoints = dto.TempHitpoints,
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
                Inventory = inventory
            };
            inventory.CharacterSheet = character;

            _context.CharacterSheets.Add(character);
            await _context.SaveChangesAsync();

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
                Age = character.Age,
                Race = character.Race,
                Sex = character.Sex,
                MaxHitpoints = character.MaxHitpoints,
                CurrentHitpoints = character.CurrentHitpoints,
                TempHitpoints = character.TempHitpoints,
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
                Talents = new List<TalentDto>(),
                Cards = new List<CardDto>(),
                Inventory = new InventoryDto
                {
                    Id = inventory.Id,
                    Items = new List<ItemDto>()
                }
            });
        }
    }
}