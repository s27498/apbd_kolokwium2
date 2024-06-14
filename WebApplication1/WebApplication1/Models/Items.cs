using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Items))]
public class Items
{
    [Column("Id")]
    [Key] public int Id { get; set; }
    [MaxLength(50)]
    [Column("Name")]
    public string Name { get; set; }
    [Column("Weig")]
    public int Weig { get; set; }
    public IEnumerable<Backpack_Slots> Backpacks { get; set; }
}