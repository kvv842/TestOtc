using AutoMapper;
using OperationsService.Contracts.Dtos;
using WebApp.Models.Operations;

namespace WebApp.Mapping
{
    public class MapperProfileToViewModel : Profile
    {
        public MapperProfileToViewModel()
        {
            CreateMap<Invoice, InvoiceModel>();
            CreateMap<Bank, BankModel>();
        }
    }
}