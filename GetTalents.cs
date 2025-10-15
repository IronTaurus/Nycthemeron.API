using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;

namespace Nycthemeron.API;

public class GetTalents
{
    public List<Talent> Agility()
    {
        var agilityTalents = new List<Talent>
        {
            new Talent //Quick Reactions I
            {
                Title = "Quick Reactions I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "Your base initiative is increased by 2.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 1 }
                },
                Cost = 5
            },
            new Talent //Quick Reactions II
            {
                Title = "Quick Reactions II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "Your base initiative is increased by 2.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 3 }
                },
                Cost = 5
            },
            new Talent //Quick Reactions III
            {
                Title = "Quick Reactions III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "Your base initiative is increased by 2.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 5 }
                },
                Cost = 5
            },
            new Talent //High Alert I
            {
                Title = "High Alert I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "For the first round only, your initiative is increased by 6. (Usable: once/combat)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 2 }
                },
                Cost = 10
            },
            new Talent //High Alert II
            {
                Title = "High Alert II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "For the first round only, your initiative is increased by 6. (Usable: once/combat)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 4 }
                },
                Cost = 10
            },
            new Talent //Light-footed I
            {
                Title = "Light-footed I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +1 in Acrobatics checks. 

                Twilights have a value of +1 during Acrobatics checks. 
                If you do not have a Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 1 }
                },
                Cost = 5
            },
            new Talent //Light-footed II
            {
                Title = "Light-footed II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "You may draw an additional card in the act of Acrobatic. (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 3 }
                },
                Cost = 10
            },
            new Talent //Light-footed III
            {
                Title = "Light-footed III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +2 in Acrobatics checks. 


                You may draw 1 additional card during Acrobatic checks then remove 1 card of your choice. 
                In addition to its other effects, Twilights are considered a Critical Success during Acrobatic Checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 5 }
                },
                Cost = 15
            },
            new Talent //Stealth I
            {
                Title = "Stealth I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +1 to Stealth checks. 
                
                Twilights have a value of +1 during stealth checks. 
                If you do not have a Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 1 }
                },
                Cost = 5
            },
            new Talent //Stealth II
            {
                Title = "Stealth II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "Draw an additional card during Stealth checks (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 3 }
                },
                Cost = 10
            },
            new Talent //Stealth III
            {
                Title = "Stealth III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +2 in Stealth checks. 
                
                You may draw 1 additional card in the act of Stealth then remove 1 card of your choice. 
                In addition to its other effects, Twilight are considered a Critical Success during Stealth Checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 5 }
                },
                Cost = 15
            },
            new Talent //Disarm Trap I
            {
                Title = "Disarm Trap I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +1 to Disarm Trap checks.
                
                Twilights have a value of +1 during Disarm Trap checks. 
                If you do not have a Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 1 }
                },
                Cost = 5
            },
            new Talent //Disarm Trap II
            {
                Title = "Disarm Trap II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "Draw an additional card during Disarm Trap checks (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 3 }
                },
                Cost = 10
            },
            new Talent //Disarm Trap III
            {
                Title = "Disarm Trap III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +2 in Disarm Trap checks.

                You may draw 1 additional card in the act of Disarm Trap then remove 1 card of your choice. 
                In addition to its other effects, Twilight are considered a Critical Success during Disarm Trap Checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 5 }
                },
                Cost = 15
            },
            new Talent //Lock Picking I
            {
                Title = "Lock Picking I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +1 to Lock Picking checks. 
                
                Twilights have a value of +1 during Lock Picking checks. 
                If you do not have a Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 1 }
                },
                Cost = 5
            },
            new Talent //Lock Picking II
            {
                Title = "Lock Picking II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "Draw an additional card during Lock Picking checks (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 3 }
                },
                Cost = 10
            },
            new Talent //Lock Picking III
            {
                Title = "Lock Picking III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"You have +2 in Lock Picking checks. 
                
                You may draw 1 additional card in the act of Lock Picking then remove 1 card of your choice. 
                In addition to its other effects, Twilights are considered a Critical Success during Lock Picking Checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 5 }
                },
                Cost = 15
            },
            new Talent //Nimble Feet I
            {
                Title = "Nimble Feet I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = "When using a movement action you may ignore and move over minor obstacles and terrain.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 2 }
                },
                Cost = 10
            },
            new Talent //Twilight Blood
            {
                Title = "Twilight Blood",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Agility" }
                },
                Description = @"(You may not have more than 3 Feats named Twilight) 
                The maximum number of Twilight cards are increased by 1. 
                Add one Twilight card to your Action deck.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Agility", Value = 4 }
                },
                Cost = 15
            }
        };
        return agilityTalents;
    }
    public List<Talent> Body()
    {
        var bodyTalents = new List<Talent>
        {
            new Talent // Orcish Strength I
            {
                Title = "Orcish Strength I",
                    TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = @"You have +1 to Strength checks. 
                
                Twilights have a value of +1 during Strength checks. 
                If you do not have an Twilights card in your deck add one. 
                (The maximum number of Twilight in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 1 }
                },
                Cost = 5
            },
            new Talent // Orcish Strength II
            {
                Title = "Orcish Strength II",
                    TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Draw an additional card during a Strength check. (Usable: Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 3 }
                },
                Cost = 10
            },
            new Talent // Orcish Strength III
            {
                Title = "Orcish Strength III",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = @"You have +2 in Strength checks.

                You may draw 1 additional card during Strength checks then remove 1 card of your choice.
                In addition to its other effects, Twilights are considered a Critical Success during Strength checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 4 }
                },
                Cost = 15
            },
            new Talent // Climber I
            {
                Title = "Climber I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = @"You have +1 to Climbing checks.

                Twilights have a value of +1 during Climbing checks. 
                If you do not have an Twilights card in your deck add one. 
                (The maximum number of Twilight in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 1 }
                },
                Cost = 5
            },
            new Talent // Climber II
            {
                Title = "Climber II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Draw an additional card during a Climbing check. (Usable: Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 3 }
                },
                Cost = 10
            },
            new Talent // Climber III
            {
                Title = "Climber III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = @"You have +2 in Climbing checks.

                You may draw 1 additional card during Climbing checks then remove 1 card of your choice.
                In addition to its other effects, Twilights are considered a Critical Success during Climbing checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 4 }
                },
                Cost = 15
            },
            new Talent // Steel Body I
            {
                Title = "Steel Body I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Whenever you are hit by a physical attack you may ignore any negative conditions that would affect you by that attack. (Usable once/combat)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 2 }
                },
                Cost = 10
            },
            new Talent // Steel Body II
            {
                Title = "Steel Body II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "In addition to its other effects, Steel Body now also halves the damage taken by the attack rounded down.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 3 }
                },
                Cost = 10
            },
            new Talent // Resilient I
            {
                Title = "Resilient I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Increase your maximum health by 10.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 1 }
                },
                Cost = 5
            },
            new Talent // Resilient II
            {
                Title = "Resilient II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Increase your maximum health by 15.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 3 }
                },
                Cost = 10
            },
            new Talent // Resilient III
            {
                Title = "Resilient III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Increase your maximum health by 15.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 5 }
                },
                Cost = 15
            },
            new Talent // Resilient IV
            {
                Title = "Resilient IV",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Increase your maximum health by 3 for each point in Body you have.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 7 }
                },
                Cost = 15
            },
            new Talent // Carrier I
            {
                Title = "Carrier I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "You encumber limit is increased by 8kg.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 1 }
                },
                Cost = 5
            },
            new Talent // Carrier II
            {
                Title = "Carrier II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "You encumber limit is increased by 8kg.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 3 }
                },
                Cost = 5
            },
            new Talent // Carrier III
            {
                Title = "Carrier III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "You encumber limit is increased by 12kg.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 5 }
                },
                Cost = 10
            },
            new Talent // Carrier IV
            {
                Title = "Carrier IV",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "You encumber limit is increased by 2 for each point in Body",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 7 }
                },
                Cost = 15
            },
            new Talent // Natural Armour
            {
                Title = "Natural Armour",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "While you don't have any Armour equipped you have Armour 2.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 2 }
                },
                Cost = 10
            },
            new Talent // Poison Immunity
            {
                Title = "Poison Immunity",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Chose a type of poison, you are immune to intake of the chosen poison in the form of food or drink. \n\nPoison Types include: Immobilizing (Sedative, Paralyzing, etc), Deadly and Mind Altering.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 5 }
                },
                Cost = 15
            },
        };
        return bodyTalents;
    }
    public List<Talent> Mind()
    {
        var mindTalents = new List<Talent>
        {
            new Talent
            {
                Title = "Insight I",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You always have +1 to any Reading checks. 

                Twilights has a value of +1 during Reading checks. 
                If you do not have an Twilights card in your deck add one. 
                (The maximum number of Twilights in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Insight II",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = "Draw an additional card during Reading checks (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Insight III",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You have +2 in Reading checks.

                You may draw 1 additional card in the act of Reading then remove 1 card of your choice. 
                In addition to its other effects, Twilights are considered a Critical Success during Reading Checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge: History I",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You always have +1 to any Knowledge: History checks. 
                
                Twilights has a value of +1 during Knowledge: History checks. 
                If you do not have an Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Knowledge: History II",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = "Draw an additional card during Knowledge: History checks (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge: History III",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You have +2 in Knowledge: History checks. 
                
                You may draw 1 additional card in the act of Knowledge: History then remove 1 card of your choice. 
                In addition to its other effects, Twilights are considered a Critical Success during Knowledge: History Checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge: Culture I",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You always have +1 to any Knowledge: Culture checks.

                Twilights has a value of +1 during Knowledge: Culture checks. 
                If you do not have an Twilights card in your deck add one. 
                (The maximum number of Twilights in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Knowledge: Culture II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = "Draw an additional card during Knowledge: Culture checks (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge: Culture III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You have +2 in Knowledge: Culture checks. 
                
                You may draw 1 additional card in the act of Knowledge: Culture then remove 1 card of your choice. 
                In addition to its other effects, Twilights are considered a Critical Success during Knowledge: Culture Checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Investigator I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You always have +1 to any Investigation checks. 
                
                Twilights has a value of +1 during Investigation checks. 
                If you do not have an Twilights card in your deck add one. 
                (The maximum number of Twilights in your deck is 1).",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Investigator II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = "Draw an additional card during Investigation checks (Once/Action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Investigator III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" }
                },
                Description = @"You have +2 in Investigation checks.
                
                You may draw 1 additional card in the act of Investigation then remove 1 card of your choice.
                In addition to its other effects, Twilights are considered a Critical Success during Investigation checks.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 5 }
                },
                Cost = 10
            }
        };
        return mindTalents;

    }
    public List<Talent> Mystic()
    {
        var mysticTalents = new List<Talent>
        {
            new Talent
            {
                Title = "Trained Spirit I",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Your spirit is increased by 15.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Trained Spirit II",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Your spirit is increased by 15.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Trained Spirit III",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Your spirit is increased by 15.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Trained Spirit IV",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Your spirit is increased by 4 for each point in Mystics.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 7 }
                },
                Cost = 15
            },
            new Talent
            {
                Title = "Twilight Spirit",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "The maximum number of Twilights are increased by 1.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Ward Maker I",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"Do a Knowledge: Arcane check and a 10min ritual spending material worth 10gold.
                You are able to make a ward of the chosen type. 
                The range of the ward is 5+ (2 x Mystics) in meters and lasts for 8h.

                -Evil Ward: The warded area is invisible to the ill intended.
                -Wanderer Ward: The warded area is invisible to the chosen creature type. (Spirits, Beasts, Humanoid, etc)
                -Spell ward: Magical or Divine effects ends and can't be inflicted in the warded area.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 2 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Ward Maker II",
                                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"Wards range is now 8 + (3 x Mystics) in meters and lasts 12h.
                                
                In addition to its other effects:
                You can now reset the duration by making another cost free ritual.

                Wards now also causes warded creatures to avoid the warded area.
                Spell Ward now also blocks spells from entering the warded area.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 4 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Divine Rituals I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Make a Knowledge: Religion check and a 10 min ritual to connect with a specific divine or demonic entity.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Divine Rituals II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"You have a +1 to Knowledge: Religion checks for the purpose of Divine Rituals.
                In addition to its other effects: With a Knowledge: Religion check you are able to fully understand a ritual of divine or demonic nature and what it is trying to accomplish.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Scroll Writer I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Not yet implemented.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Scroll Writer II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Not yet implemented.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Scroll Writer III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Not yet implemented.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Invasive Mind I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "The difficulty of checks caused by your inflictions/attacks are increased by 1.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 2 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Invasive Mind II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "The difficulty of checks caused by your inflictions/attacks are increased by 1.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 4 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Invasive Mind III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "The difficulty of checks caused by your inflictions/attacks are increased by 1.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 6 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Invasive Mind IV",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "The difficulty of checks caused by your inflictions/attacks are increased by 1.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 8 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Knowledge Religion I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"You have +1 to Knowledge: Religion check.

                Twilights has a value of +1 during Knowledge: Religion checks.
                If you do not have an Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Knowledge Religion II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"Draw an additional card during Knowledge: Religion checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge Religion III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"You have +2 in Knowledge: Religion checks.

                In addition to its other effects, Twilights are considered a Critical Success during Knowledge: Religion checks.
                You may draw 1 additional card in the act of Knowledge: Religion then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge Arcana I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"You have +1 to Knowledge: Arcana check.

                Twilights has a value of +1 during Knowledge: Religion checks.
                If you do not have an Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Knowledge Arcana II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"Draw an additional card during Knowledge: Arcana checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge Arcana III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"You have +2 in Knowledge: Arcana checks.

                In addition to its other effects, Twilights are considered a Critical Success during Knowledge: Arcana checks.
                You may draw 1 additional card in the act of Knowledge: Arcana then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Rune Crafting I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Not yet implemented.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Rune Crafting II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Not yet implemented.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Rune Crafting III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = "Not yet implemented.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge Alchemy I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"You have +1 to Knowledge: Alchemy check.

                Twilights has a value of +1 during Knowledge: Religion checks.
                If you do not have an Twilight card in your deck add one. 
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Knowledge Alchemy II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"Draw an additional card during Knowledge: Alchemy checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Knowledge Alchemy III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" }
                },
                Description = @"You have +2 in Knowledge: Alchemy checks.

                In addition to its other effects, Twilights are considered a Critical Success during Knowledge: Alchemy checks.
                You may draw 1 additional card in the act of Knowledge: Alchemy then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 5 }
                },
                Cost = 10
            },
        };
        return mysticTalents;

    }
    public List<Talent> Presence()
    {
        var presenceTalents = new List<Talent>
        {
            new Talent
            {
                Title = "Disguise I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +1 in Disguise checks.

                Twilights has a value of +1 during Disguise checks.
                If you do not have an Twilight card in your deck add one.
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Disguise II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Draw an additional card during Disguise checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Disguise III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Disguise checks.

                In addition to its other effects, Twilights are considered a Critical Success during Disguise checks.\n\n 
                You may draw 1 additional card in the act of Disguise then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Performance I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +1 in Performance checks.

                Twilights has a value of +1 during Performance checks.
                If you do not have an Twilight card in your deck add one.
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Performance II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Draw an additional card during Disguise checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Performance III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Performance checks.

                In addition to its other effects, Twilights are considered a Critical Success during Performance checks.\n\n 
                You may draw 1 additional card in the act of Performance then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Leadership I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +1 in Leadership checks.

                Twilights has a value of +1 during Leadership checks.
                If you do not have an Twilight card in your deck add one.
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Leadership II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Draw an additional card during Leadership checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Leadership III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Leadership checks.

                In addition to its other effects, Twilights are considered a Critical Success during Leadership checks.\n\n 
                You may draw 1 additional card in the act of Leadership then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Animal Handling I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +1 in Animal Handling checks.

                Twilights has a value of +1 during Animal Handling checks.
                If you do not have an Twilight card in your deck add one.
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Animal Handling II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Draw an additional card during Animal Handling checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Animal Handling III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Animal Handling checks.

                In addition to its other effects, Twilights are considered a Critical Success during Animal Handling checks.\n\n 
                You may draw 1 additional card in the act of Animal Handling then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Silver Tounge I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +1 in Persuasion checks.

                Twilights has a value of +1 during Persuasion checks.
                If you do not have an Twilight card in your deck add one.
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Silver Tounge II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Draw an additional card during Persuasion checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Silver Tounge III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Persuasion checks.

                In addition to its other effects, Twilights are considered a Critical Success during Persuasion checks.\n\n 
                You may draw 1 additional card in the act of Persuasion then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Snakes Tounge I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +1 in Deception checks. 

                Twilights has a value of +1 during Deception checks.
                If you do not have an Twilight card in your deck add one.
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Snakes Tounge II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Draw an additional card during Deception checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Snakes Tounge III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Deception checks.

                In addition to its other effects, Twilights are considered a Critical Success during Deception checks.\n\n 
                You may draw 1 additional card in the act of Deception then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Intimidation I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +1 in Intimidation checks.

                Twilights has a value of +1 during Intimidation checks.
                If you do not have an Twilight card in your deck add one.
                (The maximum number of Twilights in your deck is 1)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Intimidation II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Draw an additional card during Intimidation checks (once/action)",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 3 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Intimidation III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Intimidation checks.

                In addition to its other effects, Twilights are considered a Critical Success during Intimidation checks.\n\n 
                You may draw 1 additional card in the act of Intimidation then remove 1 card of your choice.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 5 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Etiquette: Origin",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"Chose a culture or profession.
               You know the proper way of etiquette of the chosen culture or profession.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 5
            },
        };
        return presenceTalents;
    }
    public List<Talent> Basic()
    {
        var basicTalents = new List<Talent>
        {
            new Talent
            {
                Title = "Weapon Expertize",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Basic" }
                },
                Description = @"Chose a weapon.
                You are not affected by the penalty of using the chosen weapon.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Basic", Value = 0 }
                },
                Cost = 5
            },
            new Talent
            {
                Title = "Armor Expertize",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Basic" }
                },
                Description = @"Chose an armortype (Light, Medium, Heavy).
                You are not affected by the penalty of using the chosen armor.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Basic", Value = 0 }
                },
                Cost = 5
            },
        };
        return basicTalents;
    }
    public List<Talent> Multi()
    {
        var multiTalents = new List<Talent>
        {
            new Talent
            {
                Title = "Talk with animal",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mind" },
                    new TalentType { Name = "Presence" }
                },
                Description = @"Chose an animal.
                You are able to understand and communicate with animals of the chosen type.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mind", Value = 1 },
                    new Requirement { Attribute = "Presence", Value = 1 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Sense: Soul I",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" },
                    new TalentType { Name = "Presence" }
                },
                Description = @"By concentrating you are able to sense if there are any lingering souls in the vicinity of you equal to 10 x Presence in meters.  

                A 10 minutes ritual enables you to see the souls for up to 5 x Mystic in minutes or for as long as you uphold the ritual. 
                During this effect you are also seen by any souls and spirits.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 2 },
                    new Requirement { Attribute = "Presence", Value = 1 }          
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Sense: Soul II",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" },
                    new TalentType { Name = "Presence" }
                },
                Description = @"In addition to its other effects the ritual of Sense: Soul enables you to also communicate with the lingering souls. 

                The range of which you can sense souls is increased to 20 x Presence meters
                and you are able to sense if the souls are hostile or not at half of that distance",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 3 },
                    new Requirement { Attribute = "Presence", Value = 2 }
                },
                Cost = 10
            },
            new Talent
            {
                Title = "Sense: Soul III",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" },
                    new TalentType { Name = "Presence" }
                },
                Description = @"In addition to its other effects the ritual of Sense: Soul enables you to physically interact with lingering souls or spirits.
                You can also see the souls in the living but not interact with them. 
                The duration of the ritual effect is increased to 10 x Mystic in minutes.

                While under the effect of Sense: Soul you may at any time choose to become invisible to any souls and spirits.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 4 },
                    new Requirement { Attribute = "Presence", Value = 2 }
                },
                Cost = 15
            },
            
        };
        return multiTalents;
    }

}