using AutoMapper;
using OperationsService.Contracts.Dtos;
using WebApp.Models.Operations;

namespace WebApp.Mapping
{
    public class MapperProfileFromViewModel : Profile
    {
        public MapperProfileFromViewModel()
        {
            CreateMap<TransferModel, TransferRequest>();
        }
    }
}