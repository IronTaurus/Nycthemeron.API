namespace Nycthemeron.API.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<User> ActiveUsers { get; set; } = new();
        public List<CharacterSheet> Characters { get; set; } = new();
        public List<UserGroup> UserGroups { get; set; } = new();

        // The Game Master of the Group
        public int? GameMasterId { get; set; }
        public User GameMaster { get; set; } = null!;

        


    }
}