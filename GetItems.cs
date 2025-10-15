using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;

namespace Nycthemeron.API;

public class GetWeapons
{
    public List<Weapon> Melee()
    {
        var meleeWeapons = new List<Weapon>
        {
            new Weapon
            {
                Title = "Dagger",
                Type = "Melee",
                Damage = 1,
                Range = 1,
                Grip = "One-handed",
                WeightClass = "Light",
                InitativeMod = 2,
                MovementMod = 0,
                DamageTypes = ["Piercing", "Slashing"],
                Penalties = ["-2 Initiative"],
            },
            new Weapon
            {
                Title = "Dagger of Teth",
                Type = "Melee",
                Damage = 1,
                Range = 1,
                Grip = "One-handed",
                WeightClass = "Light",
                InitativeMod = 2,
                MovementMod = 0,
                DamageTypes = ["Piercing", "Slashing", "Fire"],
                Penalties = ["-2 Initiative"],
                Effects = ["This weapon have 'n' charges. (Leaving it outside in the morning sun for at least an hour recharges the weapon.)", "Whenever you deal damage with Dagger of Teth: You may spend any number of charges and inflict Burning X where X is the number of charges spent this way."],
            },
            new Weapon
            {
                Title = "Long Sword",
                Type = "Melee",
                Damage = 2,
                Range = 1,
                Grip = "One-handed",
                WeightClass = "Medium",
                InitativeMod = 0,
                MovementMod = 0,
                DamageTypes = ["Piercing", "Slashing"],
                Penalties = ["-2 Initiative"],
            },
            new Weapon
            {
                Title = "Hand Axe",
                Type = "Melee",
                Damage = 3,
                Range = 1,
                Grip = "One-handed",
                WeightClass = "Medium",
                InitativeMod = -2,
                MovementMod = 0,
                DamageTypes = ["Slashing"],
                Penalties = ["-2 Initiative"],
            },
            new Weapon
            {
                Title = "Battle Axe",
                Type = "Melee",
                Damage = 5,
                Range = 1,
                Grip = "Two-handed",
                WeightClass = "Heavy",
                InitativeMod = -2,
                MovementMod = 0,
                DamageTypes = ["Slashing"],
                Penalties = ["-3 Initiative"],
            },
            new Weapon
            {
                Title = "Spear",
                Type = "Melee",
                Damage = 3,
                Range = 2,
                Grip = "Two-handed",
                WeightClass = "Heavy",
                InitativeMod = -1,
                MovementMod = 0,
                DamageTypes = ["Piercing"],
                Penalties = ["-3 Initiative"],
                Effects = [],
            },
            new Weapon
            {
                Title = "War Hammer",
                Type = "Melee",
                Damage = 2,
                Range = 2,
                Grip = "One-handed",
                WeightClass = "Medium",
                InitativeMod = -2,
                MovementMod = 0,
                DamageTypes = ["Bludgeon", "Armor Crushing 2"],
                Penalties = ["-2 Initiative"],
            },
            new Weapon
            {
                Title = "Maul",
                Type = "Melee",
                Damage = 3,
                Range = 2,
                Grip = "Two-handed",
                WeightClass = "Heavy",
                InitativeMod = -2,
                MovementMod = 0,
                DamageTypes = ["Bludgeon", "Armor Crushing 4"],
                Penalties = ["-3 Initiative"],
            },

        };
        return meleeWeapons;
    }
    public List<Weapon> Ranged()
    {
        var rangedWeapons = new List<Weapon>
        {
            new Weapon
            {
                Title = "Short Bow",
                Type = "Ranged",
                Damage = 2,
                Range = 14,
                Grip = "One-handed",
                WeightClass = "Light",
                InitativeMod = 1,
                ReloadPenalty = ["-2 Movement"],
                MovementMod = 0,
                DamageTypes = ["Piercing"],
                Penalties = ["-2 Range", "-1 Initative"],
            },
            new Weapon
            {
                Title = "Long Bow",
                Type = "Ranged",
                Damage = 3,
                Range = 16,
                Grip = "Two-handed",
                WeightClass = "Medium",
                InitativeMod = 1,
                ReloadPenalty = ["-2 Movement"],
                MovementMod = 0,
                DamageTypes = ["Piercing"],
                Penalties = ["-2 Range", "-1 Initative"],
            },
            new Weapon
            {
                Title = "Bow of Minarith",
                Type = "Ranged",
                Damage = 3,
                Range = 16,
                Grip = "Two-handed",
                WeightClass = "Medium",
                InitativeMod = 1,
                ReloadPenalty = ["-2 Movement"],
                MovementMod = 0,
                DamageTypes = ["Piercing", "Radiant"],
                Penalties = ["-2 Range", "-1 Initative"],
                Effects = ["This weapon have 'n' charges. (Leaving it outside in the morning sun for at least an hour recharges the weapon.)", "Whenever you attack: Instead of using a normal arrow you may spend a charge to create a Arrow of light dealing 1 additional Radiant damage."]
            },
            new Weapon
            {
                Title = "Hand Crossbow",
                Type = "Ranged",
                Damage = 2,
                Range = 12,
                Grip = "One-handed",
                WeightClass = "Light",
                InitativeMod = 0,
                ReloadPenalty = ["-1 Action of your choice", "-2 Movement"],
                MovementMod = 0,
                DamageTypes = ["Piercing", "Armor Piercing 1"],
                Penalties = ["-1 Range", "-1 Initative"],
            },
            new Weapon
            {
                Title = "Hand Crossbow",
                Type = "Ranged",
                Damage = 3,
                Range = 17,
                Grip = "Two-handed",
                WeightClass = "Light",
                InitativeMod = 0,
                ReloadPenalty = ["-1 Standard Action", "-2 Movement"],
                MovementMod = -1,
                DamageTypes = ["Piercing", "Armor Piercing 3"],
                Penalties = ["-1 Range", "-1 Initative"],
            },
        };
        return rangedWeapons;
    }
    public List<Weapon> Magic()
    {
        var magicalWeapon = new List<Weapon>
        {
            new Weapon
            {
                Title = "Small Focus",
                Type = "Focus",
                Damage = 0,
                Range = 5,
                Grip = "Zero-handed",
                WeightClass = "Light",
                InitativeMod = 0,
                MovementMod = 0,
                DamageTypes = ["Magic"],
                Penalties = ["-1 Range"],
                Effects = [],
                Notes = "A small inscription or gem that can be inserted into an object (e.g. a helmet or necklace)."
            },
            new Weapon
            {
                Title = "Medium Focus",
                Type = "Focus",
                Damage = 0,
                Range = 8,
                Grip = "One-handed",
                WeightClass = "Light",
                InitativeMod = 1,
                MovementMod = 0,
                DamageTypes = ["Magic"],
                Penalties = ["-1 Initiative","-2 Range"],
                Effects = [],
                Notes = "A small handheld object (e.g. a wand or crystal)."
            },
            new Weapon
            {
                Title = "Large Focus",
                Type = "Focus",
                Damage = 1,
                Range = 12,
                Grip = "Two-handed",
                WeightClass = "Light",
                InitativeMod = 0,
                MovementMod = 0,
                DamageTypes = ["Magic"],
                Penalties = ["-1 Initiative","-2 Range"],
                Effects = [],
                Notes = "A large object held with two hands (e.g. a staff)."

            },
            new Weapon
            {
                Title = "Small Instrument",
                Type = "Instrument",
                Damage = 1,
                Range = 6,
                Grip = "One-handed",
                WeightClass = "Light",
                InitativeMod = 1,
                MovementMod = 0,
                DamageTypes = ["Magic"],
                Penalties = ["-1 Initiative","-1 Range"],
                Effects = [],
                Notes = "A small instrument that can be used using one hand (e.g. a flute or harmonica)."
            },
            new Weapon
            {
                Title = "Large Instrument",
                Type = "Instrument",
                Damage = 2,
                Range = 10,
                Grip = "One-handed",
                WeightClass = "Light",
                InitativeMod = -1,
                MovementMod = 0,
                DamageTypes = ["Magic"],
                Penalties = ["-1 Initiative","-1 Range"],
                Effects = [],
                Notes = "A large instrument that requires two hands (e.g. a Lute or drum"
            },
        };
        return magicalWeapon;
    }

}