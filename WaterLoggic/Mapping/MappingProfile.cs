using AutoMapper;
using MService;
using WaterLoggic.Core.Dto;
using WaterLoggic.Core.Models;

namespace CakeShop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MOrderDto, MOrder>();
            CreateMap<MachineDto, Machine>();

            CreateMap<Machine, MachineDto>();
        }
    }
}
