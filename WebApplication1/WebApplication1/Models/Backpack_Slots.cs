using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Backpack_Slots))]
public class Backpack_Slots
{
    [Key]
    [Column("PK")]
    public int PK { get; set; }
    [Column("FK_item")]
    public int FK_item { get; set; }
    [ForeignKey(nameof(FK_item))]
    public Items Items { get; set; }
    [Column("FK_character")]
    
    public int FK_character { get; set; }
    [ForeignKey(nameof(FK_character))]
    public Characters Characters { get; set; }
    
}