using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers;

public class MovieController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public MovieController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> MovieList()
    {
        ViewBag.v1 = "Film Listesi";
        ViewBag.v2 = "Ana Sayfa";
        ViewBag.v3 = "Tüm Filmler";

        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7225/api/Movies");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);

            return View(values);
        }

        return View();
    }
}

