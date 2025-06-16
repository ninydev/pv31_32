using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVCApp.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}