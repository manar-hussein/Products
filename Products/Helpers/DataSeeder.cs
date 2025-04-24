using Microsoft.AspNetCore.Identity;
using Products.Models;

namespace Products.Helpers
{
    public class DataSeeder
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DataSeeder(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        private async Task CreateSallerRole()
        {
            var sallerRole = new ApplicationRole { Name = "Saller" };
            await _roleManager.CreateAsync(sallerRole);
        }
    }
}
