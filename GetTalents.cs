using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Data;
using Nycthemeron.API.Models;

namespace Nycthemeron.API;

public class GetTalents
{
    private readonly List<Talent> allTalents;
    public GetTalents()
    {
        var agilityTalents = Agility();
        var bodyTalents = Body();
        var mindTalents = Mind();
        var mysticTalents = Mystic();
        var presenceTalents = Presence();
        var multiTalents = Multi();
        var basicTalents = Basic();

        allTalents = agilityTalents
            .Concat(bodyTalents)
            .Concat(mindTalents)
            .Concat(mysticTalents)
            .Concat(presenceTalents)
            .Concat(multiTalents)
            .Concat(basicTalents)
            .ToList();
    }
    
    private List<Talent> Agility(){
        return new List<Talent>
        {
            new Talent // Quick Reactions I
            {
                Title = "Quick Reactions I",
                Key = "quick_reactions_1",
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
            new Talent // Quick Reactions II
            {
                Title = "Quick Reactions II",
                Key = "quick_reactions_2",
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
            new Talent // Quick Reactions III
            {
                Title = "Quick Reactions III",
                Key = "quick_reactions_3",
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
            new Talent // High Alert I
            {
                Title = "High Alert I",
                Key = "high_alert_1",
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
            new Talent // High Alert II
            {
                Title = "High Alert II",
                Key = "high_alert_2",
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
            new Talent // Light-footed I
            {
                Title = "Light-footed I",
                Key = "light_footed_1",
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
            new Talent // Light-footed II
            {
                Title = "Light-footed II",
                Key = "light_footed_2",
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
            new Talent // Light-footed III
            {
                Title = "Light-footed III",
                Key = "light_footed_3",
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
            new Talent // Stealth I
            {
                Title = "Stealth I",
                Key = "stealth_1",
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
            new Talent // Stealth II
            {
                Title = "Stealth II",
                Key = "stealth_2",
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
            new Talent // Stealth III
            {
                Title = "Stealth III",
                Key = "stealth_3",
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
            new Talent // Disarm Trap I
            {
                Title = "Disarm Trap I",
                Key = "disarm_trap_1",
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
            new Talent // Disarm Trap II
            {
                Title = "Disarm Trap II",
                Key = "disarm_trap_2",
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
            new Talent // Disarm Trap III
            {
                Title = "Disarm Trap III",
                Key = "disarm_trap_3",
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
            new Talent // Lock Picking I
            {
                Title = "Lock Picking I",
                Key = "lock_picking_1",
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
            new Talent // Lock Picking II
            {
                Title = "Lock Picking II",
                Key = "lock_picking_2",
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
            new Talent // Lock Picking III
            {
                Title = "Lock Picking III",
                Key = "lock_picking_3",
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
            new Talent // Nimble Feet I
            {
                Title = "Nimble Feet I",
                Key = "nimble_feet_1",
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
            new Talent // Twilight Blood
            {
                Title = "Twilight Blood",
                Key = "twilight_blood",
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

    }
    private List<Talent> Body()
    {
        return new List<Talent>
        {
            new Talent // Giant's Strength I
            {
                Title = "Giant's Strength I",
                Key = "giants_strength_1",
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
            new Talent // Giant's Strength II
            {
                Title = "Giant's Strength II",
                Key = "giants_strength_2",
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
            new Talent // Giant's Strength III
            {
                Title = "Giant's Strength III",
                Key = "giants_strength_3",
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
                Key = "climber_1",
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
                Key = "climber_2",
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
                Key = "climber_3",
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
                Key = "steel_body_1",
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
                Key = "steel_body_2",
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
                Key = "resilient_1",
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
                Key = "resilient_2",
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
                Key = "resilient_3",
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
                Key = "resilient_4",
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
                Key = "carrier_1",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Your encumber limit is increased by 8kg.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 1 }
                },
                Cost = 5
            },
            new Talent // Carrier II
            {
                Title = "Carrier II",
                Key = "carrier_2",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Your encumber limit is increased by 8kg.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 3 }
                },
                Cost = 5
            },
            new Talent // Carrier III
            {
                Title = "Carrier III",
                Key = "carrier_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Your encumber limit is increased by 12kg.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 5 }
                },
                Cost = 10
            },
            new Talent // Carrier IV
            {
                Title = "Carrier IV",
                Key = "carrier_4",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Your encumber limit is increased by 2 for each point in Body",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 7 }
                },
                Cost = 15
            },
            new Talent // Natural Armour
            {
                Title = "Natural Armour",
                Key = "natural_armour",
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
                Key = "poison_immunity",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Body" }
                },
                Description = "Choose a type of poison, you are immune to intake of the chosen poison in the form of food or drink. \n\nPoison Types include: Immobilizing (Sedative, Paralyzing, etc), Deadly and Mind Altering.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Body", Value = 5 }
                },
                Cost = 15
            },
        };

    }
    private List<Talent> Mind()
    {
        return new List<Talent>
        {
            new Talent
            {
                Title = "Insight I",
                Key = "insight_1",
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
                Key = "insight_2",
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
                Key = "insight_3",
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
                Key = "knowledge_history_1",
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
                Key = "knowledge_history_2",
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
                Key = "knowledge_history_3",
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
                Key = "knowledge_culture_1",
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
                Key = "knowledge_culture_2",
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
                Key = "knowledge_culture_3",
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
                Key = "investigator_1",
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
                Key = "investigator_2",
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
                Key = "investigator_3",
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

    }
    private List<Talent> Mystic()
    {
        return new List<Talent>
        {
            new Talent
            {
                Title = "Trained Spirit I",
                Key = "trained_spirit_1",
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
                Key = "trained_spirit_2",
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
                Key = "trained_spirit_3",
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
                Key = "trained_spirit_4",
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
                Key = "twilight_spirit",
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
                Key = "ward_maker_1",
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
                Key = "ward_maker_2",
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
                Key = "divine_rituals_1",
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
                Key = "divine_rituals_2",
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
                Key = "scroll_writer_1",
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
                Key = "scroll_writer_2",
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
                Key = "scroll_writer_3",
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
                Key = "invasive_mind_1",
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
                Key = "invasive_mind_2",
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
                Key = "invasive_mind_3",
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
                Key = "invasive_mind_4",
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
                Key = "knowledge_religion_1",
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
                Key = "knowledge_religion_2",
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
                Key = "knowledge_religion_3",
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
                Key = "knowledge_arcana_1",
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
                Key = "knowledge_arcana_2",
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
                Key = "knowledge_arcana_3",
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
                Key = "rune_crafting_1",
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
                Key = "rune_crafting_2",
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
                Key = "rune_crafting_3",
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
                Key = "knowledge_alchemy_1",
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
                Key = "knowledge_alchemy_2",
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
                Key = "knowledge_alchemy_3",
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

    }
    private List<Talent> Presence()
    {
        return new List<Talent>
        {
            new Talent
            {
                Title = "Disguise I",
                Key = "disguise_1",
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
                Key = "disguise_2",
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
                Key = "disguise_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Disguise checks.

                In addition to its other effects, Twilights are considered a Critical Success during Disguise checks.

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
                Key = "performance_1",
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
                Key = "performance_2",
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
                Key = "performance_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Performance checks.

                In addition to its other effects, Twilights are considered a Critical Success during Performance checks.

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
                Key = "leadership_1",
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
                Key = "leadership_2",
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
                Key = "leadership_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Leadership checks.

                In addition to its other effects, Twilights are considered a Critical Success during Leadership checks.

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
                Key = "animal_handling_1",
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
                Key = "animal_handling_2",
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
                Key = "animal_handling_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Animal Handling checks.

                In addition to its other effects, Twilights are considered a Critical Success during Animal Handling checks.

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
                Key = "silver_tounge_1",
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
                Key = "silver_tounge_2",
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
                Key = "silver_tounge_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Persuasion checks.

                In addition to its other effects, Twilights are considered a Critical Success during Persuasion checks.

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
                Key = "snakes_tounge_1",
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
                Key = "snakes_tounge_2",
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
                Key = "snakes_tounge_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Deception checks.

                In addition to its other effects, Twilights are considered a Critical Success during Deception checks.

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
                Key = "intimidation_1",
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
                Key = "intimidation_2",
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
                Key = "intimidation_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Presence" }
                },
                Description = @"You have +2 in Intimidation checks.

                In addition to its other effects, Twilights are considered a Critical Success during Intimidation checks.

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
                Key = "etiquette_origin",
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

    }
    private List<Talent> Multi()
    {
        return new List<Talent>
        {
            new Talent
            {
                Title = "Talk with animal",
                Key = "talk_with_animal",
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
                Key = "sense_soul_1",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" },
                    new TalentType { Name = "Presence" }
                },
                Description = @"By concentrating you are able to sense if there are any lingering souls in the vicinity 
                of you equal to 10 x Presence in meters.

                A 10 minutes ritual enables you to see the souls for up to 5 x Mystic in minutes or for as long 
                as you uphold the ritual. During this effect you are also seen by any souls and spirits.",
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
                Key = "sense_soul_2",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" },
                    new TalentType { Name = "Presence" }
                },
                Description = @"In addition to its other effects the ritual of Sense: Soul enables you to also 
                communicate with the lingering souls.

                The range of which you can sense souls is increased to 20 x Presence meters
                and you are able to sense if the souls are hostile or not at half of that distance.",
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
                Key = "sense_soul_3",
                TalentTypes = new List<TalentType>
                {
                    new TalentType { Name = "Mystic" },
                    new TalentType { Name = "Presence" }
                },
                Description = @"In addition to its other effects the ritual of Sense: Soul enables you to physically 
                interact with lingering souls or spirits.

                You can also see the souls in the living but not interact with them. 
                The duration of the ritual effect is increased to 10 x Mystic in minutes.

                While under the effect of Sense: Soul you may at any time choose to become invisible 
                to any souls and spirits.",
                Requirements = new List<Requirement>
                {
                    new Requirement { Attribute = "Mystic", Value = 4 },
                    new Requirement { Attribute = "Presence", Value = 2 }
                },
                Cost = 15
            }
        };

    }
    private List<Talent> Basic()
    {
        return new List<Talent>
        {
            new Talent
            {
                Title = "Weapon Expertize",
                Key = "weapon_expertize",
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
                Key = "armor_expertize",
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

    }

    public List<Talent> GetMany(params string[] keys)
    {
        return allTalents
            .Where(t => keys.Contains(t.Key))
            .ToList();
    }
}