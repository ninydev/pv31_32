using Microsoft.AspNetCore.Identity;

namespace WebApplicationAuth.Entities;

public class MyIdentityUserModel : IdentityUser
{
    public string? TelegramId { get; set; } = string.Empty;
    public string? TelegramUserName { get; set; } = string.Empty;
}