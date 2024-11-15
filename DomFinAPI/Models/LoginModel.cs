namespace DomFinAPI.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }

}
