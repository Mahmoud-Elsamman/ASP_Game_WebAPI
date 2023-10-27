using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_core_API.Dtos.Character;
using ASP_core_API.Dtos.Weapon;
using ASP_core_API.Models;

namespace ASP_core_API.Services.WeaponService
{
    public interface IWeaponService
    {
        public Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}