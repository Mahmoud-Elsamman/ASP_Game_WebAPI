using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_core_API.Models;
using ASP_core_API.Services.CharacterService;
using ASP_core_API.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ASP_core_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int Id)
        {
            return Ok(await _characterService.GetCharacterById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updateCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(Id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }

}

