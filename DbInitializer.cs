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

        var getTalents = new GetTalents();
        var talents = getTalents.GetMany();

        var races = new GetRace().Races();

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
            context.SaveChanges(); // <- ensures testUser.Id is set

            // 2️⃣ Create the group without GameMasterId
            var defaultGroup = new Group
            {
                Name = "Test Group",
                GameMasterId = null
            };
            context.Groups.Add(defaultGroup);
            context.SaveChanges(); // <- ensures defaultGroup.Id is set

            // 3️⃣ Create the linking entity
            var userGroup = new UserGroup
            {
                UserId = testUser.Id,
                GroupId = defaultGroup.Id,
                IsGameMaster = false
            };
            context.UserGroups.Add(userGroup);
            context.SaveChanges();
        }


        context.Talents.AddRange(talents);
        context.Items.AddRange(globalWeapons);
        context.Races.AddRange(races);
        context.SaveChanges();
    }
    
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key; // unique salt
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}