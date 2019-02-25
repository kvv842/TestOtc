using OperationsService.Contracts;
using OperationsService.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApp.Controllers.Api
{
    //[Authorize]
    public class BanksController : ApiController
    {
        private readonly IOperationsService _operationsService;

        public BanksController(IOperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        // GET: Operations
        public async Task<IEnumerable<Bank>> GetBanksAsync()
        {
            var banks = await _operationsService.GetBanksAsync();
            return banks;
        }
    }
}
