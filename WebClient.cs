using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using WebApiClientConsoleApp.Models;

namespace WebApiClientConsoleApp
{
    public static class WebClient
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<DrawResult> ProcessDrawResults(int n)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var streamTask = client.GetStreamAsync($"https://www.lotto.pl/api/lotteries/draw-results/by-gametype?game=EuroJackpot&index=1&size={n}&sort=drawDate&order=DESC");
            var drawResults = await JsonSerializer.DeserializeAsync<DrawResult>(await streamTask);

            return drawResults;
        }
    }
}