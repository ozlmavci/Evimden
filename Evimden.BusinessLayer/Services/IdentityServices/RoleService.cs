using AutoMapper;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.IdentityServices
{
    public class RoleService : Service<CustomRole, CustomRoleDto>, IRoleService
    {
        private readonly RoleManager<CustomRole> _roleManager;
        private readonly UserManager<CustomUser> _userManager;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<CustomRole> roleManager, ILogger<CustomRole> logger, UserManager<CustomUser> userManager) : base(unitOfWork, mapper, logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<CustomRoleDto> AddRoleAsync(CustomRoleDto customRoleDto)
        {
            try
            {
                CustomRole customRole = new CustomRole()
                {
                    Name = customRoleDto.Name,
                    NormalizedName = customRoleDto.NormalizedName
                };
                var result = await _roleManager.CreateAsync(customRole);
                if (result.Succeeded)
                {
                    return _mapper.Map<CustomRoleDto>(customRole);
                }
                else
                {
                    _logger.LogError("Rol ekleme başarısız oldu: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddRoleAsync metodu hata oluşturdu. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<bool> AssignRoleAsync(string userName, string roleName)
        {
            bool response = false;
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                _logger.LogError("Kullanıcı bulunamadı.");
                throw new Exception("Kullanıcı bulunamadı.");
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                _logger.LogError("Kullanıcı bu role sahip.");
                throw new Exception("Rol bulunamadı.");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName); 
            if (!result.Succeeded)
            {
                _logger.LogError("Rol atama başarısız oldu: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                throw new Exception("Rol atama başarısız oldu.");
            }
            response = true;
            return response;
        }
    }
}

