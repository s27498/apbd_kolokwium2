using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table(nameof(Characters_Titles))]
[PrimaryKey(nameof(FK_charact), nameof(FK_title))]
public class Characters_Titles
{
    [Column("FK_charact")]
    public int FK_charact { get; set; }
    [ForeignKey(nameof(FK_charact))] 
    public Characters Character { get; set; }
    [Column("FK_title")]
    public int FK_title { get; set; }
    [ForeignKey(nameof(FK_title))] 
    public Titles Title { get; set; }
    [Column("aquire_at")]
    public DateTime aquire_at { get; set; }
}