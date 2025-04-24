using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.ViewModels.Authantication;
using System.Security.Claims;

namespace Products.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(UserManager<ApplicationUser> userManager,
                                        RoleManager<ApplicationRole> roleManager,
                                        SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var appUser = viewModel.Adapt<ApplicationUser>();
            var result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Somthing Went Wrong", $"Can't Register");
                return View(viewModel);
            }
            var roleResult = await _userManager.AddToRoleAsync(appUser, "Saller");
            if (!roleResult.Succeeded)
            {
                ModelState.AddModelError("Somthing Went Wrong", $"Can't Register");
                return View(viewModel);
            }

            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LogInViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user is null)
            {
                ModelState.AddModelError("UserNotFound", "User Or Password Wrong");
                return View(viewModel);
            }
            var isCorrectPass = await _userManager.CheckPasswordAsync(user, viewModel.Password);
            if (!isCorrectPass)
            {
                ModelState.AddModelError("UserNotFound", "User Or Password Wrong");
                return View(viewModel);
            }
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
            // Add any additional claims
            await _signInManager.SignInAsync(user, viewModel.RememberMe);
            return RedirectToAction("Index", "Saller");
        }
        public async Task<IActionResult> CreateSallerRole()
        {
            var sallerRole = new ApplicationRole { Name = "Saller" };
            await _roleManager.CreateAsync(sallerRole);
            return Ok();
        }
        public async Task<IActionResult> CreateBuyerRole()
        {
            var sallerRole = new ApplicationRole { Name = "Buyer" };
            await _roleManager.CreateAsync(sallerRole);
            return Ok();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }

    }
}
