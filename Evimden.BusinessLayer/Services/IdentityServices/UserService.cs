using AutoMapper;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.IdentityServices
{
    public class UserService : Service<CustomUser, CustomUserDto>, IUserService
    {
        private readonly UserManager<CustomUser> _userManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<CustomUser> userManager, ILogger<CustomUser> logger) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
        }

        public async Task<CustomUserDto> UserRegisterAsync(CustomUserDto customUserDto)
        {
            try
            {
                CustomUser customUser = new CustomUser()
                {
                    UserName = customUserDto.UserName,
                    Email = customUserDto.Email,
                    FirstName = customUserDto.FirstName,
                    LastName = customUserDto.LastName,
                    PhoneNumber = customUserDto.PhoneNumber
                };
                var result = await _userManager.CreateAsync(customUser, customUserDto.Password);
                if (result.Succeeded)
                {
                    return _mapper.Map<CustomUserDto>(customUser);
                }
                else
                {
                    _logger.LogError($"UserRegisterAsync metodu hata oluşturdu. Hata: {result.Errors}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"UserRegisterAsync metodu hata oluşturdu. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<CustomUserDto> UserLoginAsync(CustomUserDto customUserDto)
        {
            try
            {
                var result = await _userManager.FindByNameAsync(customUserDto.UserName);
                if (result != null && await _userManager.CheckPasswordAsync(result, customUserDto.Password))
                {
                    CustomUserDto response = new CustomUserDto()
                    {
                        Id = result.Id,
                        UserName = result.UserName,
                        Email = result.Email,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        PhoneNumber = result.PhoneNumber
                    };
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"UserLoginAsync metodu hata oluşturdu. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<CustomUserDto> UserUpdateAsync(CustomUserDto customUserDto)
        {
            try
            {
                CustomUser customUser = new CustomUser()
                {
                    Id = customUserDto.Id,
                    UserName = customUserDto.UserName,
                    Email = customUserDto.Email,
                    FirstName = customUserDto.FirstName,
                    LastName = customUserDto.LastName,
                    PhoneNumber = customUserDto.PhoneNumber
                };
                var result = await _userManager.UpdateAsync(customUser);
                if (result.Succeeded)
                {
                    return _mapper.Map<CustomUserDto>(customUser);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"UserUpdateAsync metodu hata oluşturdu. Hata: {ex.Message}");
                throw ex;
            }

        }

        public async Task<CustomUserDto> PasswordChangeAsync(CustomUserDto customUserDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(customUserDto.UserName);
                var result = await _userManager.ChangePasswordAsync(user, customUserDto.Password, customUserDto.NewPassword);
                if (result.Succeeded)
                {
                    return customUserDto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"PasswordChangeAsync metodu hata oluşturdu. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<List<string>> GetUserRolesAsync(Guid userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                var roles = await _userManager.GetRolesAsync(user);
                return roles.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetUserRolesAsync metodu hata oluşturdu. Hata: {ex.Message}");
                throw ex;
            }
        }
    }
}
