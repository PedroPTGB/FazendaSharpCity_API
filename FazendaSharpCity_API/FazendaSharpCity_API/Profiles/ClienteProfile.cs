using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Models;

namespace FazendaSharpCity_API.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
        CreateMap<Cliente, ReadClienteDto>().ForMember(clienteDto => clienteDto.Endereco,opt => opt.MapFrom(cliente => cliente.Endereco));
    }
}
