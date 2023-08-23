using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Resunet.Models;

namespace Resunet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly ICurrentUser currentUser;

    public HomeController(ILogger<HomeController> logger, ICurrentUser currentUser)
    {
        this.logger = logger;
        this.currentUser =currentUser;
    }

    public IActionResult Index()
    {
        return View(currentUser.isLoggedIn());
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

