using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstMVCApp.Entities;

[Table("Cars")]
public class CarEntity
{
    // Navigation property to ManufacturerEntity
    // ONE CarEntity belongs to ONE ManufacturerEntity
    [ForeignKey(nameof(Manufacturer))]
    [Column("ManufacturerId")]
    [Required]
    public int ManufacturerId { get; set; }

    public ManufacturerEntity Manufacturer { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Column("ModelName", TypeName = "nvarchar(50)")]
    public string ModelName { get; set; } = string.Empty;

    [Required]
    [Range(1900, 2100)]
    [Column("Year")]
    public int Year { get; set; }

    // Navigation property to CarEntity
    // MANY CarColorEntity can be associated with MANY CarEntities  
    public ICollection<CarColorEntity> Colors { get; set; } = new List<CarColorEntity>();

    [Required]
    [Range(0, 10000000)]
    [Column("Price", TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    // Временные метки
    [Required]
    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column("UpdatedAt")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Soft delete
    [Required]
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; } = false;
}