using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class GetDTO
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public int Money { get; set; }
    public IEnumerable<ItemsDTO> BackpackItems { get; set; }
    public IEnumerable<TitleDTO> Titles { get; set; }
}

public class ItemsDTO
{
    public int SlotId { get; set; }
    [MaxLength(50)]
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
}

public class TitleDTO
{
    [MaxLength(100)]
    public string Title { get; set; }
    public DateTime AquireAt { get; set; }
}