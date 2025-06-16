using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVCApp.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewData["MessageData"] = "Hello ViewData from ContactController!";
        ViewBag.MessageBag = "Hello ViewBag from ContactController!";
        return View();
    }


    // public string GetString()
    // {
    //     return "Hello from ContactController!";
    //     // return View("Index");
    // }
}