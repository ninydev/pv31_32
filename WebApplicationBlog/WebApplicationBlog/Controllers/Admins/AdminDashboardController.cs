using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBlog.Controllers.Admins;

[Route("admin/")]
[Authorize(Roles = "Admin")]
public class AdminDashboardController : Controller
{
    [HttpGet ("")]
    public IActionResult Index()
    {
        // Здесь можно добавить логику для получения данных для админской панели
        return View();
    }
    
    [HttpGet("tags")]
    public IActionResult Tags()
    {
        return View();
    }
}