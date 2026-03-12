using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminDtos.AdminSeriesDtos;
using Newtonsoft.Json;

namespace SeriesApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSeriesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminSeriesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> SeriesList()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7225/api/Serieses");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultSeriesDto>>(jsonData);

                return View(values);
            }

            return View();
        }


        [HttpGet]
        public IActionResult CreateSeries()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(AdminCreateSeriesDto Series)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(Series);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7225/api/Serieses", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList", "AdminSeries", new { area = "Admin" });
            }
        
            return View();
        }
    }
}
