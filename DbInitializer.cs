using Nycthemeron.API.Models;
using Nycthemeron.API.Data;
using Nycthemeron.API;
using System.Security.Cryptography;
using System.Text;

public static class DbInitializer
{
    public static void Initialize(GameDbContext context)
    {
        // WARNING: This deletes everything in the database
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var agility = new GetTalents().Agility();
        var body = new GetTalents().Body();
        var mind = new GetTalents().Mind();
        var mystic = new GetTalents().Mystic();
        var presence = new GetTalents().Presence();
        var multi = new GetTalents().Multi();
        var basic = new GetTalents().Basic();

        var talents =
        agility
        .Concat(body)
        .Concat(mind)
        .Concat(mystic)
        .Concat(presence)
        .Concat(multi)
        .Concat(basic)
        .ToList();

        var melee = new GetWeapons().Melee();
        var ranged = new GetWeapons().Ranged();
        var magic = new GetWeapons().Magic();

        var globalWeapons =
        melee
        .Concat(ranged)
        .Concat(magic)
        .ToList();

        // Create a test user if none exists
        if (!context.Users.Any())
        {
            CreatePasswordHash("password", out byte[] passwordHash, out byte[] passwordSalt);

            var testUser = new User
            {
                UserName = "user",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Admin = false
            };

            context.Users.Add(testUser);
            context.SaveChanges();
        }


        context.Talents.AddRange(talents);
        context.Items.AddRange(globalWeapons);
        context.SaveChanges();
    }
    
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key; // unique salt
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}