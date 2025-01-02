using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.UI.Web.Models.VMs.IdentityVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Evimden.UI.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly CustomAuthenticationStateProvider _authenticationStateProvider;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly ISellerService _sellerservice;

        public UserController(UserManager<CustomUser> userManager, IUserService userService, CustomAuthenticationStateProvider authenticationStateProvider, SignInManager<CustomUser> signInManager, ISellerService sellerService)
        {
            _userService = userService;
            _authenticationStateProvider = authenticationStateProvider;
            _signInManager = signInManager;
            _sellerservice = sellerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserVM model = new UserVM();
            if (TempData["ModelState"] != null)
            {
                var modelState = TempData["ModelState"] as ModelStateDictionary;
                if (modelState != null)
                {
                    foreach (var item in modelState)
                    {
                        ModelState.AddModelError(item.Key, item.Value.Errors.First().ErrorMessage);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _authenticationStateProvider.MarkUserAsLoggedOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserVM model)
        {
            if (model.Transaction == 0)
            {
                if (!ModelState.IsValid)
                {
                    TempData["ModelState"] = ModelState;
                    return View();
                }
                if (model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError("", "Şifreler uyuşmuyor, kontrol ediniz.");
                    TempData["ModelState"] = ModelState;
                    return View();
                }

                CustomUserDto customUser = new CustomUserDto()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber
                };

                var user = await _userService.UserRegisterAsync(customUser);

                if (user == null)
                {
                    ModelState.AddModelError("", "Kayıt başarısız.");
                    TempData["ModelState"] = ModelState;
                    return View();
                }
                return View();
            }
            else
            {
                if (model.UserName == null || model.Password == null)
                {
                    TempData["ModelState"] = ModelState;
                    return View();
                }

                CustomUserDto customUserDto = new CustomUserDto()
                {
                    UserName = model.UserName,
                    Password = model.Password
                };

                var user = await _userService.UserLoginAsync(customUserDto);

                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                    TempData["ModelState"] = ModelState;
                    return View();
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                    // Add roles to claims
                    var roles = await _userService.GetUserRolesAsync(user.Id);
                    foreach (var role in roles)
                    {
                        if (role == "Satıcı")
                        {
                            var sellerId = _sellerservice.GetSellerIdByUserIdAsync(user.Id);
                            claims.Add(new Claim(ClaimTypes.PostalCode, sellerId.ToString()));
                        }
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    _authenticationStateProvider.MarkUserAsAuthenticated(user.UserName, claims);

                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}
