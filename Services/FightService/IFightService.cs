using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ASP_core_API.Dtos.Fight;
using ASP_core_API.Models;

namespace ASP_core_API.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto weaponAttack);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto skillAttack);

    }
}