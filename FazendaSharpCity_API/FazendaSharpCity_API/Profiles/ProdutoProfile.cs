using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Funcionario;
using FazendaSharpCity_API.Data.DTOs.Produto;
using FazendaSharpCity_API.Models;

namespace FazendaSharpCity_API.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<UpdateProdutoDto, Produto>();
            CreateMap<Produto, UpdateProdutoDto>();
            CreateMap<Produto, ReadProdutoDto>();
        }
    }
}
