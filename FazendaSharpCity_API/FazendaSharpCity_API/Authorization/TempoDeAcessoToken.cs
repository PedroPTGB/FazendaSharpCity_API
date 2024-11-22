using Microsoft.AspNetCore.Authorization;

namespace FazendaSharpCity_API.Authorization
{
    public class TempoDeAcessoToken : IAuthorizationRequirement
    {
        public bool TempoDeAcessoValido { get; set; }

        public TempoDeAcessoToken(bool tempoDeAcessoValido)
        {
            TempoDeAcessoValido = tempoDeAcessoValido;
        }
    }
}
