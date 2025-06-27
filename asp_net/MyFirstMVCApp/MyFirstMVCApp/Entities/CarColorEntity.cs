using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstMVCApp.Entities;

public class CarColorEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(30)]
    [Column("ColorName", TypeName = "nvarchar(30)")]
    public string ColorName { get; set; } = string.Empty;
    
    [StringLength(128)]
    [Column("ColorUrl", TypeName = "nvarchar(30)")]
    public string? ColorUrl { get; set; } = string.Empty;
    
    [Required]
    [StringLength(7)]
    [Column("HexCode", TypeName = "nvarchar(7)")]
    public string HexCode { get; set; } = string.Empty;
    
    // Navigation property to CarEntity
    // MANY CarColorEntity can be associated with MANY CarEntities  
    public ICollection<CarEntity> Cars { get; set; } = new List<CarEntity>();
}