using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_core_API.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Damage { get; set; }
        public List<CharacterSkill> CharacterSkills { get; set; }

    }
}