using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class OutfitController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OutfitController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("GetClosetItems")]
    public async Task<IActionResult> GetClosetItems()
    {
        var client = _httpClientFactory.CreateClient("ClosetService");
        var response = await client.GetAsync("/api/clothing"); // Call Closet Service's endpoint

        if (response.IsSuccessStatusCode)
        {
            var items = await response.Content.ReadAsStringAsync();
            return Ok(items);
        }
        return StatusCode((int)response.StatusCode);
    }
}
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace OutfitService.Services
// {
//     public class ClosetServiceHttpClient
//     {
//         private readonly HttpClient _httpClient;
//         private readonly IConfiguration _config;
//         public ClosetServiceHttpClient(HttpClient httpClient, IConfiguration config)
//         {
//             _config = config;
//             _httpClient = httpClient;
            
//         }

//         public async Task<IActionResult> GetClosetItems()
//     }
// }