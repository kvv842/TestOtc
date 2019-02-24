using OperationsService.Contracts;
using OperationsService.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApp.Controllers.Api
{
    //[Authorize]
    public class InvoicesController : ApiController
    {
        private readonly IOperationsService _operationsService;

        public InvoicesController(IOperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        // GET: Operations
        public async Task<IEnumerable<Invoice>> GetInvoicesAsync(Guid id)
        {
            var invoices = await _operationsService.GetSenderInvoicesAsync(id);
            return invoices;
        }
    }
}
