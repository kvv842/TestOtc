namespace AuthService.Contracts.Dtos
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }

        public int UserId { get; set; }

        public string Login { get; set; }
    }
}
