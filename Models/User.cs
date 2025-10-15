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

    }
}