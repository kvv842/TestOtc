using AuthService.Contracts.Dtos;
using System.Threading.Tasks;

namespace AuthService.Contracts
{
    public interface IAuthService
    {
        Task<bool> AuthAsync(AuthRequest authRequest);
    }
}
