using Microsoft.AspNetCore.Identity;

namespace LojaMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? NomeCompleto { get; set; }
    }
}