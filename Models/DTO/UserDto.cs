namespace Nycthemeron.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public bool Admin { get; set; }
    }
    
        public class UserRegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Admin { get; set; } = false;
    }
}