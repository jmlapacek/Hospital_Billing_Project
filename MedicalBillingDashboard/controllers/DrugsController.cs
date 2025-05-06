using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class DrugsController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public DrugsController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrugData()
    {
        string apiUrl = "https://data.cms.gov/data-api/v1/dataset/7e0b4365-fd63-4a29-8f5e-e0ac9f66a81b/data";

        try
        {
            var response = await _httpClient.GetStringAsync(apiUrl);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var drugs = JsonSerializer.Deserialize<List<DrugInfo>>(response, options);

            // Optional: limit to top 50 results
            var limitedDrugs = drugs?.GetRange(0, Math.Min(50, drugs.Count));

            return Ok(limitedDrugs);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error fetching CMS data: {ex.Message}");
        }
    }
}

// ✅ DrugInfo model (you can move this to a separate file under Models folder if needed)
public class DrugInfo
{
    public string drug_name { get; set; }
    public string manufacturer_name { get; set; }
    public string total_drug_cost_per_unit { get; set; }
}
