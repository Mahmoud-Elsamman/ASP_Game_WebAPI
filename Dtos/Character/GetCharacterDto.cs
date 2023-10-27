using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_core_API.Dtos.Skill;
using ASP_core_API.Dtos.Weapon;
using ASP_core_API.Models;

namespace ASP_core_API.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Frodo";

        public int Hitpoints { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;

        public int Intelligence { get; set; } = 10;

        public RpgClass Class { get; set; } = RpgClass.knight;

        public GetWeaponDto Weapon { get; set; }

        public List<GetskillDto> Skills { get; set; }
    }
}