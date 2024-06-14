using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controller;
[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService _inventoryService;

    public InventoryController(InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertToInventoty(IEnumerable<int> Ids, int CharacterId)
    {
        if (!await _inventoryService.DoesCharacterExist(CharacterId))
        {
            return NotFound("Character with given id does not exist.");
        }
        if (!await _inventoryService.DoesItemExist(Ids))
        {
            return NotFound("Wrong id has been provided - item does not exist.");
        }
        if (!await _inventoryService.CanCharacterPickUp(Ids, CharacterId))
        {
            return BadRequest("This character cannot pick up this load!");
        }

        if (await _inventoryService.IsItemInInventory(CharacterId, Ids))
        {
            return BadRequest("Item already in inventory!");
        }

        var result = await _inventoryService.InsertIntoInventory(Ids, CharacterId);
        return Ok(result);
    }
}