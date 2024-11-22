using Microsoft.AspNetCore.Authorization;

namespace FazendaSharpCity_API.Authorization
{
    public class IsFuncionario : IAuthorizationRequirement
    {
        private bool v;

        public IsFuncionario(bool v)
        {
            this.v = v;
        }
    }
}