namespace PracticeAPI.Model
{
    public class AuthResponse
    {
        public int? UserId { get; set; }
        public int? IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
