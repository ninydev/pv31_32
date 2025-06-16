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

    public IActionResult ByIdFromPath(int id)
    {
        ViewData ["MessageData"] = $"Hello ViewData from ContactController with ID: {id}!";
        return View("Index");
    }
    
    public IActionResult ByNameAndAge(string name, int age)
    {
        ViewData["MessageData"] = $"Name: {name}, Age: {age}";
        return View("Index");
    }
    


    // public string GetString()
    // {
    //     return "Hello from ContactController!";
    //     // return View("Index");
    // }
}