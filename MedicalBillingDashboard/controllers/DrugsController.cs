using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

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
            return Content(response, "application/json");
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error fetching CMS data: {ex.Message}");
        }
    }
}
