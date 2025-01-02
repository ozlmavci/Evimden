using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.UI.Web.Models.VMs;
using Evimden.UI.Web.Models.VMs.IdentityVMs;
using Evimden.UI.Web.Models.VMs.RoleVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Evimden.UI.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RoleController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string message)
        {
            if (!message.IsNullOrEmpty())
            {
                ViewBag.Message = message;
            }
            var result = await _roleService.GetAllAsync();
            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult AddRole(string message)
        {
            if (!message.IsNullOrEmpty())
            {
                ViewBag.Message = message;
            }
            return View(new CustomRoleDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(CustomRoleDto customRoleDto)
        {
            try
            {
                var result = await _roleService.AddRoleAsync(customRoleDto);
                if (result != null)
                {
                    TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                    {
                        Success = true,
                        Message = "Rol başarıyla eklendi."
                    });
                }
                else
                {
                    TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                    {
                        Success = false,
                        Message = "Rol ekleme başarısız oldu."
                    });
                }
            }
            catch (Exception ex)
            {
                TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(Guid id)
        {
            var role = await _roleService.GetByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(CustomRoleDto customRoleDto)
        {
            try
            {
                await _roleService.UpdateAsync(customRoleDto);

                TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                {
                    Success = true,
                    Message = "Rol başarıyla güncellendi."
                });
            }
            catch (Exception ex)
            {
                TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            try
            {
                await _roleService.DeleteAsync(id);
                TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                {
                    Success = true,
                    Message = "Rol başarıyla silindi."
                });
            }
            catch (Exception ex)
            {
                TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole()
        {
            var users = await _userService.GetAllAsync();
            var roles = await _roleService.GetAllAsync();

            var model = new AssignRoleVM
            {
                Users = users.Select(u => new UserMiniVM
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).ToList(),
                Roles = roles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleVM model)
        {
            try
            {
                if (model.UserId != Guid.Empty || !model.RoleName.IsNullOrEmpty())
                {
                    var result = await _roleService.AssignRoleAsync(model.UserName, model.RoleName);
                    if (result)
                    {
                        TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                        {
                            Success = true,
                            Message = "Rol başarıyla atandı."
                        });
                    }
                    else
                    {
                        TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                        {
                            Success = false,
                            Message = "Rol atama başarısız oldu."
                        });
                    }
                    return RedirectToAction("Index");
                }

                // Hatalı durumlarda tekrar kullanıcı ve rol listelerini doldur
                var users = await _userService.GetAllAsync();
                var roles = await _roleService.GetAllAsync();

                model.Users = users.Select(u => new UserMiniVM
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).ToList();
                model.Roles = roles.ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ResponseVM"] = JsonConvert.SerializeObject(new ResponseVM
                {
                    Success = false,
                    Message = ex.Message
                });
                return RedirectToAction("Index");
            }
        }
    }
}