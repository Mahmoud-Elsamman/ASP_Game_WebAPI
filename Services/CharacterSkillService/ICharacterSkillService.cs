using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_core_API.Dtos.Character;
using ASP_core_API.Dtos.CharacterSkill;
using ASP_core_API.Models;

namespace ASP_core_API.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        public Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto addCharacterSkillDto);
    }
}