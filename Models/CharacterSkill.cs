using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_core_API.Models
{
    public class CharacterSkill
    {
        public Character Character { get; set; }

        public int CharacterId { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
    }
}