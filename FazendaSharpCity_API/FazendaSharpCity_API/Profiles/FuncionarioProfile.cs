using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Funcionario;
using FazendaSharpCity_API.Models;

namespace FazendaSharpCity_API.Profiles;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<CreateFuncionarioDto, Funcionario>();
        CreateMap<UpdateFuncionarioDto, Funcionario>();
        CreateMap<Funcionario, UpdateFuncionarioDto>();
        CreateMap<Funcionario, ReadFuncionarioDto>().ForMember(funcionarioDto => funcionarioDto.Endereco, opt => opt.MapFrom(cliente => cliente.Endereco));
    }
}
