using System;

namespace AuthService.Contracts.Dtos
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }

        public Guid UserId { get; set; }

        public string Login { get; set; }
    }
}
