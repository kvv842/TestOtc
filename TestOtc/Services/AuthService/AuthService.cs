using AuthService.Contracts;
using AuthService.Contracts.Dtos;
using AuthService.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public class AuthService: IAuthService
    {
        public async Task<AuthResponse> AuthAsync(AuthRequest authRequest)
        {
            var db = new AuthDbContext();

            var dbUser = await db.Users.FirstOrDefaultAsync(a => a.Login == authRequest.Login && a.Password == authRequest.Password);

            if (dbUser != null)
            {
                return new AuthResponse()
                {
                    IsSuccess = true,
                    Login = dbUser.Login,
                    UserId = dbUser.Id,
                };
            }

            return new AuthResponse()
            {
                IsSuccess = false,
            }; 
        }
    }
}
