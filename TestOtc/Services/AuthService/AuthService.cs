using AuthService.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public class AuthService
    {
        public async Task<bool> AuthAsync(AuthRequest authRequest)
        {
            return await Task.FromResult(authRequest.Login == "1");
        }
    }
}
