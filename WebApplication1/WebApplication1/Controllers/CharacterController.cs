using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly CharacterService _characterService;

    public CharacterController(CharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        if (!await _characterService.DoesCharacterExist(id))
        {
            return NotFound("Character with given id does not exist!");
        }

        var response = await _characterService.GetCharacter(id);
        return Ok(response);
    }
}