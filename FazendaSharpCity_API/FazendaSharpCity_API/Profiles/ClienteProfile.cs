using AutoMapper;
using FazendaSharpCity_API.Data.DTOs;
using FazendaSharpCity_API.Models;

namespace FilmesApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
        CreateMap<Cliente, ReadClienteDto>();
    }
}
