using AutoMapper;
using OperationsService.Contracts;
using OperationsService.Contracts.Dtos;
using OperationsService.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsService
{
    public class OperationsService: IOperationsService
    {
        private readonly OperationsDbContext _operationsDbContext;

        public OperationsService(OperationsDbContext operationsDbContext)
        {
            _operationsDbContext = operationsDbContext;
        }

        public async Task<IList<Bank>> GetBanksAsync()
        {
            var dbBanks = await _operationsDbContext.Banks.ToListAsync();
            var banks = Mapper.Map<IList<Bank>>(dbBanks);
            return banks;
        }
    }
}
