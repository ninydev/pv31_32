using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstMVCApp.Entities;

public class ManufacturerEntity
{
    
    // Navigation property to CarEntity
    // ONE ManufacturerEntity can have MANY CarEntities
    public List<CarEntity> Cars { get; set; } = new List<CarEntity>();
    
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string SiteUrl { get; set; } = string.Empty;
    
    public string LogoUrl { get; set; } = string.Empty;
    
    // ... other properties as needed
    
}