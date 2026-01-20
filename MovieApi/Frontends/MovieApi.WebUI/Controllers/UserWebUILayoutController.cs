using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers;

public class UserWebUILayoutController : Controller
{
    // GET
    public IActionResult LayoutUI()
    {
        return View();
    }
}