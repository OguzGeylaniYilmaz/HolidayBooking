using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class MovieAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<MovieApiViewModel> movieList = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "fbec24938cmsh72265e783cf7f28p119175jsn5e08c5864502" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var apiMovies = JsonConvert.DeserializeObject<List<MovieApiViewModel>>(body);
                return View(apiMovies);
            }
        }

    }
}
