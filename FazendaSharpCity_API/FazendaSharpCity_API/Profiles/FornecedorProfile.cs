using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Fornecedor;
using FazendaSharpCity_API.Models;

namespace FazendaSharpCity_API.Profiles;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        CreateMap<CreateFornecedorDto, Fornecedor>();
        CreateMap<UpdateFornecedorDto, Fornecedor>();
        CreateMap<Fornecedor, UpdateFornecedorDto>();
        CreateMap<Fornecedor, ReadFornecedorDto>();
    }
}
