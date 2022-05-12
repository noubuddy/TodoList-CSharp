using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList_CSharp.Models;
using TodoList_CSharp.Modules;

namespace TodoList_CSharp.Controllers;

public class HomeController : Controller
{
    private DatabaseManager dbManager;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        dbManager = new("127.0.0.1", 38015);
        // dbManager.DeleteDb("todolist");
        // dbManager.CreateDb("todolist");
        // dbManager.CreateTable("todolist", "tasks");
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public ActionResult<string> Index(string message)
    {
        if (message == null)
            return View();

        dbManager.Insert("todolist", "tasks", new Todo { message = message });
        message = "";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
