namespace Nycthemeron.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public List<CharacterSheet> Characters { get; set; }  = new();
        public bool Admin { get; set; } = false;

        public List<UserGroup> UserGroups { get; set; } = new();

        //Groups in which the user has a GM role.
        public List<Group> ManagedGroups { get; set; } = new();

    }
}