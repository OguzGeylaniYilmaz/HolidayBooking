using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Traversal.UI.Areas.Admin.Models;


namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExchangeAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {

            List<ExchangeApiViewModel> list = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "fbec24938cmsh72265e783cf7f28p119175jsn5e08c5864502" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var exchangeApi = JsonConvert.DeserializeObject<ExchangeApiViewModel>(body);
                return View(exchangeApi.exchange_rates);

            }
        }
    }
}
