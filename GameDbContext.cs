using Microsoft.EntityFrameworkCore;
using Nycthemeron.API.Models;
using System.Text.Json;
using static Nycthemeron.API.Models.Talent;

namespace Nycthemeron.API.Data;
public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options)
    {
    }

    public DbSet<Talent> Talents { get; set; }
    public DbSet<TalentType> TalentTypes { get; set; }
    public DbSet<RacialTrait> RacialTraits { get; set; }
    public DbSet<Requirement> Requirements { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<CharacterSheet> CharacterSheets { get; set; }
    public DbSet<CharacterAttribute> Attributes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }// abstract base class
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Armor> Armors { get; set; }
    public DbSet<Other> Others { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<UniqueTrait> UniqueTraits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Table names
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<CharacterSheet>().ToTable("CharacterSheet");
        modelBuilder.Entity<CharacterAttribute>().ToTable("CharacterAttribute");

        // User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Characters)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Groups
        modelBuilder.Entity<UserGroup>()
        .HasKey(ug => new { ug.UserId, ug.GroupId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.GroupId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.GameMaster)
                .WithMany(u => u.ManagedGroups)
                .HasForeignKey(g => g.GameMasterId);

        // CharacterSheet
        modelBuilder.Entity<CharacterSheet>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<CharacterSheet>()
        .HasMany(c => c.Talents)
        .WithMany(t => t.Characters)
        .UsingEntity(j => j.ToTable("CharacterSheetTalent"));

        // CharacterSheet → Attribute relationships
        modelBuilder.Entity<CharacterSheet>()
            .HasOne(c => c.Agility)
            .WithMany()
            .HasForeignKey(c => c.AgilityId);

        modelBuilder.Entity<CharacterSheet>()
            .HasOne(c => c.Body)
            .WithMany()
            .HasForeignKey(c => c.BodyId);

        modelBuilder.Entity<CharacterSheet>()
            .HasOne(c => c.Mind)
            .WithMany()
            .HasForeignKey(c => c.MindId);

        modelBuilder.Entity<CharacterSheet>()
            .HasOne(c => c.Mystic)
            .WithMany()
            .HasForeignKey(c => c.MysticId);

        modelBuilder.Entity<CharacterSheet>()
            .HasOne(c => c.Presence)
            .WithMany()
            .HasForeignKey(c => c.PresenceId);

        // Attribute
        modelBuilder.Entity<CharacterAttribute>()
            .HasKey(a => a.Id);

        //Race
        modelBuilder.Entity<Race>()
            .HasMany(r => r.UniqueTraits)
            .WithOne(ut => ut.Race)
            .HasForeignKey(ut => ut.RaceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Race>()
            .HasMany(r => r.PositiveRacialTraits)
            .WithMany()
            .UsingEntity(j => j.ToTable("RacePositiveTraits"));

        modelBuilder.Entity<Race>()
            .HasMany(r => r.NegativeRacialTraits)
            .WithMany()
            .UsingEntity(j => j.ToTable("RaceNegativeTraits"));

        //RacialTraits
        modelBuilder.Entity<RacialTrait>().ToTable("RacialTraits");

        // Talents
        modelBuilder.Entity<Talent>().ToTable("Talent");
        modelBuilder.Entity<TalentType>().ToTable("TalentType");
        modelBuilder.Entity<Requirement>().ToTable("Requirement");

        // TalentType config
        modelBuilder.Entity<TalentType>()
                .HasKey(tt => tt.Id);

        modelBuilder.Entity<TalentType>()
            .HasOne(tt => tt.Talent)
            .WithMany(t => t.TalentTypes)
            .HasForeignKey(tt => tt.TalentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Requirement config
        modelBuilder.Entity<Requirement>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Requirement>()
            .HasOne(r => r.Talent)
            .WithMany(t => t.Requirements)
            .HasForeignKey(r => r.TalentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Inventory → Items
        modelBuilder.Entity<Inventory>()
            .HasMany(i => i.Items)
            .WithOne(i => i.Inventory)
            .HasForeignKey(i => i.InventoryId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Container>()
            .HasMany(c => c.ContainingItems)
            .WithOne(i => i.Container)
            .HasForeignKey(i => i.ContainerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Item>()
            .HasDiscriminator<string>("ItemType")
            .HasValue<Weapon>("Weapon")
            .HasValue<Armor>("Armor")
            .HasValue<Other>("Other")
            .HasValue<Container>("Container")
            .HasValue<Accessory>("Accessory");

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.MainHand)
            .WithMany()
            .HasForeignKey(i => i.MainHandId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.OffHand)
            .WithMany()
            .HasForeignKey(i => i.OffHandId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.EquippedArmor)
            .WithMany()
            .HasForeignKey(i => i.EquippedArmorId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
