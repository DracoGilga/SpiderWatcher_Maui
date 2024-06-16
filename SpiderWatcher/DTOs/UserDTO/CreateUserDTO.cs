namespace SpiderWatcher.DTOs.UserDTO
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly DateBirth { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
