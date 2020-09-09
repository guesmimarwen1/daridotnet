using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


public class CustomUserLogin : IdentityUserLogin<int>
{
    public int Id { get; set; }

}
public class CustomUserRole : IdentityUserRole<int>
{
    public int Id { get; set; }
}
public class CustomUserClaim : IdentityUserClaim<int>
{

}
public class CustomRole : IdentityRole<int, CustomUserRole>
{
    public CustomRole() { }
    public CustomRole(string name) { Name = name; }
}
namespace Dari.Domain.Entities
{
    public class Client : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public TyAbo TyAbo { get; set; }
        public virtual ICollection<Meuble> Meubles { get; set; }

        public virtual ICollection<Annonce> Annonces { get; set; }

        public virtual ICollection<RDV> RDVS { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Client, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }
}
