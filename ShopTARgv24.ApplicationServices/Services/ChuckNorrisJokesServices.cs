using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;

namespace ShopTARgv24_Ksenia.ApplicationServices.Services
{
    public class ChuckNorrisJokesServices : IChuckNorrisJokesServices
    {
        private const string JokeApiUrl = "https://api.chucknorris.io/jokes/random";
        private readonly HttpClient _httpClient;
        public ChuckNorrisJokesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChuckNorrisJokesDto?> GetRandomJokeAsync()
        {
            if (string.IsNullOrWhiteSpace(JokeApiUrl)) return null;

            var responce= await _httpClient.GetAsync(JokeApiUrl);

            if (!responce.IsSuccessStatusCode) return null;

            var json = await responce.Content.ReadAsStringAsync();
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dto = JsonSerializer.Deserialize<ChuckNorrisJokesDto>(json, opts);

            return dto;

        }

    }

}
