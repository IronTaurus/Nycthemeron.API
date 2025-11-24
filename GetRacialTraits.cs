using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;

namespace Nycthemeron.API;

public class GetRacialTraits
{
    private readonly Dictionary<string, RacialTrait> _traits;
    public GetRacialTraits()
    {
        var all = new List<RacialTrait>();

        all.AddRange(Positive());
        all.AddRange(Negative());

        _traits = all.ToDictionary(t => t.Key, t => t);
    }
    public RacialTrait Get(string key)
    {
        if (_traits.TryGetValue(key, out var trait))
            return trait;

        throw new Exception($"RacialTrait with key '{key}' could not be found.");
    }
    public List<RacialTrait> GetMany(params string[] keys)
        => keys.Select(Get).ToList();

    public List<RacialTrait> Positive()
    {
        var positiveTraits = new List<RacialTrait>
        {
            new RacialTrait //Creature of the night
            {
                Title = "Creature of the night",
                Key = "night_creature",
                Type = "Positive",
                Description = @"Use the 'Creature of the Night' Action Deck instead of the normal one. 
                (The deck features 9 Sun cards, 13 Moon cards, one Critical Fail and one Critical Success)",
            },
            new RacialTrait //Creature of the Day
            {
                Title = "Creature of the Day",
                Key = "day_creature",
                Type = "Positive",
                Description = @"Use the 'Creature of the Day' Action Deck instead of the normal one. 
                (The deck features 11 Sun cards, 9 Moon cards, one Critical Fail and one Critical Success)",
            },
            new RacialTrait //Mountainborn
            {
                Title = "Mountainborn",
                Key = "mountainborn",
                Type = "Positive",
                Description = @"You have +1 to Climbing checks.",
            },
            new RacialTrait //Dwarven Knowledge
            {
                Title = "Dwarven Knowledge",
                Key = "dwarven_knowledge",
                Type = "Positive",
                Description = "+1 to Knowledge: History and Knowledge: Culture checks involving Dwarves.",
            },
            new RacialTrait //Dark Vision I
            {
                Title = "Dark Vision I",
                Key = "dark_vision_1",
                Type = "Positive",
                Description = "You have +1 to Dark Vision.",
            },
            new RacialTrait //Dark Vision II
            {
                Title = "Dark Vision II",
                Key = "dark_vision_2",
                Type = "Positive",
                Description = "You have +2 to Dark Vision.",
            },
            new RacialTrait //Dark Senses
            {
                Title = "Dark Senses",
                Key = "dark_senses",
                Type = "Positive",
                Description = "You gain +3 to Perception checks made using only your sense of smell.",
            },
            new RacialTrait //Elvish Knowledge
            {
                Title = "Elvish Knowledge",
                Key = "elvish_knowledge",
                Type = "Positive",
                Description = "+1 to Knowledge: History and Knowledge: Culture checks involving Elves.",
            },
            new RacialTrait //Hardened Skin I
            {
                Title = "Hardened Skin I",
                Key = "hardened_skin_1",
                Type = "Positive",
                Description = "You have an 5 additional Max Hitpoints.",
            },
            new RacialTrait //Hardened Skin II
            {
                Title = "Hardened Skin II",
                Key = "hardened_skin_2",
                Type = "Positive",
                Description = "You have an 10 additional Max Hitpoints.",
            },
            new RacialTrait //Iron Stomach
            {
                Title = "Hardened Gullet",
                Key = "Iron_gullet",
                Type = "Positive",
                Description = @"You have +1 to checks against minor poisoning inflictions. (Minor poisoning includes: Sedative, Alcohol, Food poisoning, etc) ]",
            },
            new RacialTrait //Light Vision I
            {
                Title = "Light Vision I",
                Key = "light_vision_1",
                Type = "Positive",
                Description = "You have +1 to Light Vision.",
            },
            new RacialTrait //Light Vision II
            {
                Title = "Light Vision II",
                Key = "light_vision_2",
                Type = "Positive",
                Description = "You have +2 to Light Vision.",
            },
            new RacialTrait //Meditative Memory
            {
                Title = "Meditative Memory",
                Key = "meditative_memory",
                Type = "Positive",
                Description = "By meditating for at least 20 minutes you may recollect any memory perfectly otherwise lost to you.",
            },
            new RacialTrait //Orcish Strength I
            {
                Title = "Orcish Strength I",
                Key = "orcish_strength_1",
                Type = "Positive",
                Description = @"You have +1 to Strength checks.",
            },
                new RacialTrait //Orcish Strength II
            {
                Title = "Orcish Strength II",
                Key = "orcish_strength_2",
                Type = "Positive",
                Description = @"You have +2 to Strength checks.",
            },
            new RacialTrait //Orcish Knowledge
            {
                Title = "Orcish Knowledge",
                Key = "orcish_knowledge",
                Type = "Positive",
                Description = "+1 to Knowledge: History and Knowledge: Culture checks involving Orcs.",
            },
            new RacialTrait //Shared Ancestry
            {
                Title = "Shared Strength",
                Key = "shared_strength",
                Type = "Positive",
                Description = @"Choose an Attribute Point and a Positive Racial Trait from a race to which you have ancestral ties. 
                You may also choose a Talent from a race to which you have ancestral ties as your choosable Talent as long as you meet the condition for it.",
            },


        };
        return positiveTraits;
    }
    public List<RacialTrait> Negative()
    {
        var negativeTraits = new List<RacialTrait>
        {
            new RacialTrait //Endless Hunger
            {
                Title = "Endless Hunger",
                Key = "endless_hunger",
                Type = "Negative",
                Description = "You have a slight hunger that never really go away.",
            },
            new RacialTrait //Iron Allergy
            {
                Title = "Iron Weakness",
                Key = "iron_weakness",
                Type = "Negative",
                Description = "Whenever you touch iron you feel sick and a chilling discomfort in the bones.",
            },
            new RacialTrait //Poor Light Vision I
            {
                Title = "Poor Light Vision I",
                Key = "poor_light_vision_1",
                Type = "Negative",
                Description = "You have -1 to Light Vision.",
            },
            new RacialTrait //Poor Light Vision II
            {
                Title = "Poor Light Vision II",
                Key = "poor_light_vision_2",
                Type = "Negative",
                Description = "You have -2 to Light Vision.",
            },
            new RacialTrait //Poor Night Vision I
            {
                Title = "Poor Dark Vision I",
                Key = "poor_dark_vision_1",
                Type = "Negative",
                Description = "You have -1 to Dark Vision.",
            },
            new RacialTrait //Poor Night Vision II
            {
                Title = "Poor Dark Vision II",
                Key = "poor_dark_vision_2",
                Type = "Negative",
                Description = "You have -2 to Dark Vision.",
            },
            new RacialTrait //Picky Sleeper
            {
                Title = "Picky Sleeper",
                Key = "picky_sleeper",
                Type = "Negative",
                Description = "Sleeping in Harsh Conditions gives you Poor Sleep.",
            },
            new RacialTrait //Sensitive Sleeper
            {
                Title = "Sensitive Sleeper",
                Key = "sensitive_sleeper",
                Type = "Negative",
                Description = "Sleeping in a lit room gives you Poor Sleep.",
            },
            new RacialTrait //Shared Weakness
            {
                Title = "Shared Weakness",
                Key = "shared_weakness",
                Type = "Negative",
                Description = "Choose a negative racial trait from a race to which you have ancestral ties.",
            },
            new RacialTrait //Short Legs
            {
                Title = "Short Legs",
                Key = "short_legs",
                Type = "Negative",
                Description = "Your movement is reduced by 1.",
            },
            new RacialTrait //Weak Mind I
            {
                Title = "Weak Mind I",
                Key = "weak_mind_1",
                Type = "Negative",
                Description = "You have -1 to Mind Infliction checks.",
            },
            new RacialTrait //Weak Mind II
            {
                Title = "Weak Mind II",
                Key = "weak_mind_2",
                Type = "Negative",
                Description = "You have -2 to Mind Infliction checks.",
            },
        };
        return negativeTraits;
    }
}