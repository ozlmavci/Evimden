﻿using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;

namespace Evimden.BusinessLayer.Interfaces.IdentityInterfaces
{
    public interface IUserLoginService : IService<CustomUserLogin, CustomUserLoginDto>
    {
    }
}