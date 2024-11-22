using Microsoft.AspNetCore.Authorization;

namespace FazendaSharpCity_API.Authorization
{
    public class NivelGerencial : IAuthorizationRequirement
    {

        public NivelGerencial(bool isGerencial)
        {
            IsGerencial = isGerencial;
        }
        public bool IsGerencial { get; set; }
    }
}
