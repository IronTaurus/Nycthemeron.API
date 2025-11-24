using Microsoft.VisualBasic;
using Nycthemeron.API.Models;

namespace Nycthemeron.API;

public class GetRace
{
    private List<RacialTrait> positiveTraits = new GetRacialTraits().Positive();
    private List<RacialTrait> negativeTraits = new GetRacialTraits().Negative();
    
    public List<Race> Races()
    {
        var getTalents = new GetTalents();
        var traits = new GetRacialTraits();

        var races = new List<Race>
        {       
            new Race //HighElf
            {
                Name = "High Elf",
                RacialFamily = "Elves",
                AgeExpectancy = 1200,
                Size = "Medium 165 - 190",
                EncumbermentLimit = 18,
                Background = @"High Elves are a branch from the Elderkin Elves from Naerini that built settlements near humans and learned to coexist with them. 
                Building cities they started to adapt to their surroundings and became the proud and beautiful people you see today.",
                Appearence = @"High Elves are known for their sharp, pointed ears—shorter than those of other elven kinds, yet still far more pronounced than a human’s. 
                They typically wear their hair long, often in very pale shades, though other colors are not uncommon. High Elves take great pride in their beauty, favoring long, 
                manicured nails and fair skin untouched by hard labor. They often dress in light, flowing garments such as silk, usually in bright colors that complement their 
                pale complexions. Their jewelry is commonly made of gold, silver, and glimmering gemstones that catch the morning sun.",
                Behaviour = @"Far less secluded than their kin, High Elves are not shy and cherish their beauty and elegance. They can often be found mingling among other races, 
                even though they frequently consider themselves superior in both status and elegance. Their love of beauty and light is reflected in their professions—many serve 
                in prestigious positions, or work as skilled artisans crafting goldwork, fine jewelry, and delicate silks.
                A typical High Elf home is a brightly colored wooden dwelling adorned with abundant decorations that cover much of its exterior. Large windows flood the interior 
                with sunlight, softened when needed by flowing silken drapes. High Elves dislike cold environments and have a strong aversion to harsh or uncomfortable sleeping 
                conditions.",
                UniqueTraits = new List<UniqueTrait>
                {
                    new UniqueTrait {Title = "Time Perception", Description = @"
                    Elves perceive time differently from most other races, largely due to their long lifespans. Much like how a person might forget performing a mundane daily 
                    chore, an elf may feel the same way about entire years. Because of this, elves tend to be selective in what they choose to remember, and it is not uncommon 
                    for them to forget the names of people they deem unimportant. Through meditation, however, elves can sort through their memories with remarkable clarity. 
                    This practice allows them to recall events—even those long forgotten—by revisiting and reorganizing the depths of their mind.
                    "},
                },
                Attributes = new List<CharacterAttribute>
                {
                    new CharacterAttribute {Title = "Mind", Value = 1, Aspiration = 1},
                    new CharacterAttribute {Title = "Presence", Value = 2, Aspiration = 2}
                },
            PositiveRacialTraits = traits.GetMany(
                    "elvish_knowledge",
                    "meditative_memory",
                    "light_vision_1"
                ),
            NegativeRacialTraits = traits.GetMany(
                    "iron_weakness",
                    "poor_dark_vision_1",
                    "picky_sleeper"
                ),
            ChooseableTalents = getTalents.GetMany(
                "knowledge_culture_1",
                "knowledge_history_1",
                "insight_1",
                "silver_tongue_1",
                "snakes_tongue_1"
            )
            },
            new Race //Darklings
            {
                Name = "Darkling",
                AgeExpectancy = 0,
                Size = "Heritage dependent",
                EncumbermentLimit = 18,
                Background = @"A Darkling is the child of a parent with demonic heritage. Regardless of the other parent’s race, 
                the child will always inherit demonic traits. In some bloodlines, which may be very old, the demonic blood can 
                thin over generations, making the features less pronounced. Due to their twisted appearance and background, 
                Darklings were historically outcasts in most societies. Today, several nations have accepted them, though they 
                may still attract curious or wary glances. Exceptions exist—such as Heln, which has a dark history with demons 
                and has actively rejected or even hunted Darklings.",
                Appearence = @"A Darkling possesses traits from multiple races, but their demonic features are the most striking. 
                Horns that can sprout from various parts of the body, long tails, or sharp teeth give them a twisted appearance, 
                marking their demonic heritage. These demonic traits are not always obvious; their visibility depends on the strength 
                and age of the bloodline. In some cases, a Darkling may appear indistinguishable from anyone else.",
                Behaviour = @"Because of their troubled history, Darklings often develop strong and contrasting views of other races. 
                Some grow deeply suspicious, believing others would betray them the moment an opportunity appears. 
                Others overcompensate for their heritage by becoming exceptionally friendly, eager to prove themselves trustworthy. 
                As a result, Darklings can seem like day and night—some of the kindest individuals one could meet, while others are 
                among the most wary and distrustful.",
                UniqueTraits = new List<UniqueTrait>
                {
                    new UniqueTrait {Title = "Bloodline Decay", Description = @"The expected lifespan of a Darkling depends on the lifespan of the race they inherit from. To calculate a Darkling’s expected lifespan, 
                    take the inherited race’s life expectancy and reduce it by approximately 20%."},
                    new UniqueTrait {Title = "Inherited Features", Description = @"As a Darkling, your features are a blend of demonic traits, the characteristics of your non-demonic parent race, 
                    and the traits of the husk—the soul turned vessel possessed by your ancestral demon."}
                },
                Attributes = new List<CharacterAttribute>
                {
                    new CharacterAttribute {Title = "Agility", Value = 1, Aspiration = 1},
                    new CharacterAttribute {Title = "Mystic", Value = 1, Aspiration = 1}
                },
            PositiveRacialTraits = traits.GetMany(
                    "shared_strength",
                    "dark_senses"
                ),
            NegativeRacialTraits = traits.GetMany(
                    "shared_weakness",
                    "endless_hunger"
                ),
            ChooseableTalents = getTalents.GetMany(
                "light_footed_1",
                "quick_reaction_1",
                "knowledge_arcana_1",
                "trained_spirit_1"
            )
            },
        };
        return races;


    }
}