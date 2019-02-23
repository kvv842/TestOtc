using OperationsService.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsService.Contracts
{
    public interface IOperationsService
    {
        Task<IList<Bank>> GetBanksAsync();
    }
}
