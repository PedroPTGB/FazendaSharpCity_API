using Microsoft.AspNetCore.Authorization;

namespace FazendaSharpCity_API.Authorization
{
    public class NivelGerencialAuthorization : AuthorizationHandler<NivelGerencial>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NivelGerencial requirement)
        {
            var NivelGerencialClaim = context.User.Claims.First(claim => claim.Type == "NivelGerencial");

            if (NivelGerencialClaim is null) return Task.CompletedTask;

            if (NivelGerencialClaim.ToString() == "true")
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
