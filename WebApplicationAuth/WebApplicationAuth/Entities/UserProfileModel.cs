using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationAuth.Entities;

public class UserProfileModel
{
    public virtual IdentityUser User { get; set; }
    
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; }
    
    public DateTime DateOfBirth { get; set; }
}