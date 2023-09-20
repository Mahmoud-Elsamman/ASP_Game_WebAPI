using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_core_API.Models;

namespace ASP_core_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 1, Name = "Sam"}
        };

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int Id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == Id));
        }

        [HttpPost]
        public IActionResult AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);

            return Ok(characters);
        }
    }

}

