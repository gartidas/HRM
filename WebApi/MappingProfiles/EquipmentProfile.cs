using AutoMapper;
using WebApi.Entities;
using static WebApi.Features.EquipmentItems.GetAllEquipmentOfEmployee;

namespace WebApi.MappingProfiles
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentDto>();
        }

    }
}
