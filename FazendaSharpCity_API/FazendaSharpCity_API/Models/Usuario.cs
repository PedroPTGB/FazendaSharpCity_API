using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Models
{
    public class Usuario : IdentityUser
    {
        //public bool NivelGerencial { get; set; }
        public Usuario() : base() { }
    }
}
