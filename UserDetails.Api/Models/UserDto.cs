namespace UserDetails.Api.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}