using Microsoft.AspNetCore.Mvc;

namespace ViteBackendIntegrationPoC.Controllers;

public class HomeController : Controller
{
    public HomeController() { }

    public IActionResult Index() => View();
}
