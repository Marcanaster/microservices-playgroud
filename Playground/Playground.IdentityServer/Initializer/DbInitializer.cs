using Duende.IdentityServer.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Playground.IdentityServer.Configuration;
using Playground.IdentityServer.Model;
using Playground.IdentityServer.Model.Context;
using System.Security.Claims;

namespace Playground.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IdentityContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(IdentityContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "Marcanaster-admin",
                Email = "marcanaster-admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "=55 (21) 95101-4154",
                FirstName= "Marcos",
                LastName = "Admin"
            };
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "MarcanasterClient",
                Email = "marcanaster-client@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "=55 (21) 95101-4154",
                FirstName= "Marcos",
                LastName = "Client"
            };

            _user.CreateAsync(admin, "Marcanaster6931$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();
            _user.CreateAsync(client, "Marcanaster6931$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)


            }).Result;

            var ClientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)


            }).Result;
        }
    }
}
