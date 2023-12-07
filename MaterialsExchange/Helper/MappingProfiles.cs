using AutoMapper;
using MaterialsExchange.Dto;
using MaterialsExchange.Models;

namespace MaterialsExchange.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Material, MaterialDto>();
            CreateMap<Seller, SellerDto>();
        }
    }
}
