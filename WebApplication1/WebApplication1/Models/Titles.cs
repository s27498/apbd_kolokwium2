using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Titles))]
public class Titles
{
    [Key]
    [Column("PK")]
    public int PK { get; set; }
    [MaxLength(100)]
    [Column("nam")]
    public string nam { get; set; }
    public IEnumerable<Characters_Titles> CharacterTitles { get; set; }
}