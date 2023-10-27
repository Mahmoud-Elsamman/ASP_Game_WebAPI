using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_core_API.Dtos.CharacterSkill;
using ASP_core_API.Services.CharacterService;
using ASP_core_API.Services.CharacterSkillService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_core_API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _characterSkillService;
        public CharacterSkillController(ICharacterSkillService characterSkillService)
        {
            _characterSkillService = characterSkillService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            return Ok(await _characterSkillService.AddCharacterSkill(newCharacterSkill));
        }

    }
}