using AutoMapper;
using OperationsService.Contracts.Dtos;
using OperationsService.Data.Entities;

namespace OperationsService.Mapping
{
    public class MapperProfileToDTO : Profile
    {
        public MapperProfileToDTO()
        {
            CreateMap<DbBank, Bank>();
        }
    }
}
