using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_core_API.Data;
using ASP_core_API.Dtos.Fight;
using ASP_core_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_core_API.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext _context;

        public FightService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto weaponAttack)
        {
            ServiceResponse<AttackResultDto> response = new ServiceResponse<AttackResultDto>();

            try
            {
                Character attacker = await _context.Characters
                    .Include(c => c.Weapon)
                    .FirstOrDefaultAsync(c => c.Id == weaponAttack.AttackerId);

                Character opponent = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == weaponAttack.OpponentId);

                int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));

                damage -= new Random().Next(opponent.Defense);

                if (damage > 0)
                    opponent.Hitpoints -= damage;

                if (opponent.Hitpoints <= 0)
                    response.Message = $"{opponent.Name} has been defeated!";

                _context.Characters.Update(opponent);
                await _context.SaveChangesAsync();

                response.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    Opponent = opponent.Name,
                    AttackerHP = attacker.Hitpoints,
                    OpponentHP = opponent.Hitpoints,
                    Damage = damage
                };

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto skillAttack)
        {
            ServiceResponse<AttackResultDto> response = new ServiceResponse<AttackResultDto>();

            try
            {
                Character attacker = await _context.Characters
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .FirstOrDefaultAsync(c => c.Id == skillAttack.AttackerId);

                Character opponent = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == skillAttack.OpponentId);

                CharacterSkill characterSkill = attacker.CharacterSkills
                    .FirstOrDefault(cs => cs.Skill.Id == skillAttack.SkillId);

                if (characterSkill == null)
                {
                    response.Success = false;
                    response.Message = $"{attacker.Name} doesn't know that skill.";
                    return response;
                }

                int damage = characterSkill.Skill.Damage + (new Random().Next(attacker.Intelligence));

                damage -= new Random().Next(opponent.Defense);

                if (damage > 0)
                    opponent.Hitpoints -= damage;

                if (opponent.Hitpoints <= 0)
                    response.Message = $"{opponent.Name} has been defeated!";

                _context.Characters.Update(opponent);
                await _context.SaveChangesAsync();

                response.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    Opponent = opponent.Name,
                    AttackerHP = attacker.Hitpoints,
                    OpponentHP = opponent.Hitpoints,
                    Damage = damage
                };

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}