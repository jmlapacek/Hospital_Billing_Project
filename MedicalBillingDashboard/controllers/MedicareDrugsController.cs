using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using MedicalBillingDashboard.models;

namespace MedicalBillingDashboard.controllers
{
    public class MedicareDrugsController : Controller
    {
        private readonly HttpClient _httpClient;

        public MedicareDrugsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://data.cms.gov/data-api/v1/dataset/7e0b4365-fd63-4a29-8f5e-e0ac9f66a81b/data?$limit=10";

            try
            {
                var json = await _httpClient.GetStringAsync(apiUrl);
                var drugs = JsonConvert.DeserializeObject<List<MedicareDrug>>(json);
                return View(drugs);
            }
            catch
            {
                ViewBag.Error = "Failed to load Medicare drug data.";
                return View(new List<MedicareDrug>());
            }
        }
    }
}
