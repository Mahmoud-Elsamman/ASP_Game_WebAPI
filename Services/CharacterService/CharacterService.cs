using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASP_core_API.Data;
using ASP_core_API.Dtos.Character;
using ASP_core_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ASP_core_API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Characters.Where(c => c.User.Id == GetUserId()).Select(character => _mapper.Map<GetCharacterDto>(character))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == Id && c.User.Id == GetUserId());
                if (character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = (_context.Characters
                            .Where(c => c.User.Id == GetUserId())
                            .Select(character => _mapper.Map<GetCharacterDto>(character)))
                            .ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharacters =
                GetUserRole().Equals("Admin") ?
                await _context.Characters.ToListAsync() :
                await _context.Characters.Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = (dbCharacters.Select(character => _mapper.Map<GetCharacterDto>(character))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character dbCharacter = await _context.Characters
                .Include(c => c.Weapon)
                .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                .FirstOrDefaultAsync(c => c.Id == Id && c.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character character = await _context.Characters.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);

                if (character.User.Id == GetUserId())
                {
                    character.Name = updateCharacter.Name;
                    character.Class = updateCharacter.Class;
                    character.Defense = updateCharacter.Defense;
                    character.Hitpoints = updateCharacter.Hitpoints;
                    character.Intelligence = updateCharacter.Intelligence;
                    character.Strength = updateCharacter.Strength;

                    _context.Characters.Update(character);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found.";
                }

            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}