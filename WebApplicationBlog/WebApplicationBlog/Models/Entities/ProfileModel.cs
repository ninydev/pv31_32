using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationBlog.Models.Entities;

[Table("Profiles")]
public class ProfileModel
{
    [NotMapped]
    public IdentityUser User;
    
    [Key, ForeignKey(nameof(User))]
    [Column("user_id", TypeName = "nvarchar(450)")]
    public string UserId { get; set; }
    
    [Column("display_name", TypeName = "nvarchar(100)")]
    [MaxLength(64)]
    public string DisplayName { get; set; }
    
    [Column("about", TypeName = "text")]
    public string About { get; set; }
    
    [Column("telegram_id", TypeName = "nvarchar(64)")]
    [MaxLength(64)]
    public string TelegramId { get; set; }
    
    [Column("telegram_username", TypeName = "nvarchar(64)")]
    [MaxLength(64)]
    public string TelegramUserName { get; set; }
    
    [Column("last_online")]
    public DateTime LastOnline { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}