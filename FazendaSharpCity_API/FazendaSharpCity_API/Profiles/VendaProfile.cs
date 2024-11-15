using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Venda;
using FazendaSharpCity_API.Models;

namespace FazendaSharpCity_API.Profiles
{
    public class VendaProfile : Profile
    {
        public VendaProfile() 
        {
            CreateMap<CreateVendaDto, Venda>();
            CreateMap<UpdateVendaDto, Venda>();
            CreateMap<Venda, UpdateVendaDto>();
            CreateMap<Venda, ReadVendaDto>();
        }
            
    }
}
