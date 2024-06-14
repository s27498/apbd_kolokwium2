using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Characters))]
public class Characters
{
    [Key]
    [Column("PK")]
    public int PK { get; set; }
    [MaxLength(50)]
    [Column("first_name")]
    public string first_name { get; set; }
    [MaxLength(50)]
    [Column("last_name")]
    public string last_name { get; set; }
    [Column("current_weig")]
    public int current_weig { get; set; }
    [Column("max_weight")]
    public int max_weight { get; set; }
    [Column("money")]
    public int money { get; set; }
    public IEnumerable<Backpack_Slots> Backpacks { get; set; }
    public IEnumerable<Characters_Titles> CharacterTitles { get; set; }
}