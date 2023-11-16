using CostAccounting.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CostAccounting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private const string baseApiUrl = "https://localhost:7297/api/purchaseApi";
        private AppDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(baseApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var note = JsonConvert.DeserializeObject<List<Purchase>>(await response.Content.ReadAsStringAsync());
                return View(note);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }


        }

        [HttpPost]
        public async Task<IActionResult> AddNote(Purchase purchase)
        {
            await _httpClient.PostAsJsonAsync(baseApiUrl, purchase);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
