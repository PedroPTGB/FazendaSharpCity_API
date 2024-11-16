using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Usuario;
using FazendaSharpCity_API.Data.DTOs.Venda;
using FazendaSharpCity_API.Models;

namespace FazendaSharpCity_API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();
            CreateMap<Usuario, UpdateUsuarioDto>();
            CreateMap<Usuario, ReadUsuarioDto>();
        }
    }
}
