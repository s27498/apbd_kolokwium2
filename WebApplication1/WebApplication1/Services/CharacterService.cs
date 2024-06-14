using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public class CharacterService
{
    private readonly ApplicationContext _context;

    public CharacterService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<GetDTO> GetCharacter(int id)
    {
        var character = await _context.CharactersEnumerable
            .Where(chr => chr.PK == id)
            .Select(chr => new GetDTO()
            {
                FirstName = chr.first_name,
                LastName = chr.last_name,
                CurrentWeight = chr.current_weig,
                MaxWeight = chr.max_weight,
                Money = chr.money,

                BackpackItems = chr.Backpacks
                    .Select(bck => new ItemsDTO()
                    {
                        SlotId = bck.PK,
                        ItemName = bck.Items.Name,
                        ItemWeight = bck.Items.Weig
                    }).ToList(),
                Titles = chr.CharacterTitles
                    .Select(tit => new TitleDTO()
                    {
                        AquireAt = tit.aquire_at,
                        Title = tit.Title.nam
                    }).ToList()

            }).FirstOrDefaultAsync();
        return character;
    }

    public async Task<bool> DoesCharacterExist(int id)
    {
        var possibleCharacter = await _context.CharactersEnumerable.FindAsync(id);
        return possibleCharacter != null;
    }
}