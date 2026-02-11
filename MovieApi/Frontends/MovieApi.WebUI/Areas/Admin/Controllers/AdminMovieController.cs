using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminMovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminMovieController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public AdminMovieController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> MovieList()
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7225/api/Movies");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsonData);

            return View(values);
        }

        return View();
    }


    [HttpGet]
    public IActionResult CreateMovie()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(AdminCreateMovieDto movie)
    {
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(movie);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7225/api/Movies", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("MovieList", "AdminMovie", new { area = "Admin" });
        }
        
        return View();
    }

}