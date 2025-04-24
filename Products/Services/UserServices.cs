using Microsoft.AspNetCore.Identity;
using Products.Models;

namespace Products.Services
{
    public class UserServices
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserServices(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

    }
}
