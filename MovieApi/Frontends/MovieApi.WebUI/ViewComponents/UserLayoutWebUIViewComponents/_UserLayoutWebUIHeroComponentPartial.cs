using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UserLayoutWebUIViewComponents;

public class _UserLayoutWebUIHeroComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // ViewBag.v1 = "Film Listesi";
        // ViewBag.v2 = "Ana Sayfa";
        // ViewBag.v3 = "Tüm Filmler";
        return View();
    }
}