using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Endereco;
using FazendaSharpCity_API.Models;

namespace FazendaSharpCity_API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
