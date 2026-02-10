using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminCategoryDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminCategoryController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public AdminCategoryController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> CategoryList()
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7225/api/Categories");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AdminResultCategoryDto>>(jsonData);

            return View(values);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(AdminCreateCategoryDto category)
    {
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(category);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7225/api/Categories", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("CategoryList");
        }

        return View();
    }


    public async Task<IActionResult> DeleteCategory(int Id)
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7225/api/Categories?id=" + Id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("CategoryList", "AdminCategory", new { area = "Admin" });
        }

        return View();
    }
}