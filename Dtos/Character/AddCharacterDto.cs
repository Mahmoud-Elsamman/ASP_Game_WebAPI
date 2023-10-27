using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_core_API.Models;

namespace ASP_core_API.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Frodo";

        public int Hitpoints { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;

        public int Intelligence { get; set; } = 10;

        public RpgClass Class { get; set; } = RpgClass.knight;
    }
}