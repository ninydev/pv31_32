using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Entities;
using WebApplicationAuth.Models; // Импортируйте пространство имён с MyIdentityUserModel

namespace WebApplicationAuth.Controllers
{
    public class TelegramController : Controller
    {
        private readonly UserManager<MyIdentityUserModel> _userManager;
        private readonly ApplicationDbContext _context;

        public TelegramController(
            ApplicationDbContext context,
            UserManager<MyIdentityUserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        // GET: TelegramController
        public async Task<ActionResult> Index()
        {
            var userName = User.Identity?.Name;
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            
            // Получение текущего пользователя из базы данных
            var user = await _userManager.GetUserAsync(User);

            // Можно передать всю сущность пользователя во ViewBag или ViewData
            ViewBag.TelegramId = user?.TelegramId; // пример свойства
            ViewBag.User = user;
            
            var profile = await _context.UserProfiles
                .FirstOrDefaultAsync(p => p.UserId == userId);

            ViewBag.Profile = profile;
            
            return View();
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: TelegramController
        public ActionResult Roles()
        {
            return View("Index");
        }
        
        public ActionResult Guest()
        {
            return View("Index");
        }
    }
}
