using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_core_API.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int Hitpoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.knight;
        public User User { get; set; }
        public int UserId { get; set; }
        public Weapon Weapon { get; set; }

        public List<CharacterSkill> CharacterSkills { get; set; }

        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}