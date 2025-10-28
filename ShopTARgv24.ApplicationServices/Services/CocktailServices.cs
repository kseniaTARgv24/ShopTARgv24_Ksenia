using System.Text.Json;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;

namespace ShopTARgv24_Ksenia.ApplicationServices.Services
{
    public class CocktailServices : ICocktailService
    {
        private readonly HttpClient _http;

        // базовый URL с тестовым ключом 1 (подходит для разработки)
        private const string BaseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

        public CocktailServices(HttpClient http)
        {
            _http = http;
            // базовый адрес можно настроить в Program.cs HttpClientFactory
        }

        public async Task<CocktailSearchResultDto?> SearchByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            // кодируем имя в URL
            var q = Uri.EscapeDataString(name.Trim());
            var url = $"{BaseUrl}search.php?s={q}"; // пример: search.php?s=margarita

            var resp = await _http.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;

            var json = await resp.Content.ReadAsStringAsync();
            // десериализуем с игнорированием регистра
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dto = JsonSerializer.Deserialize<CocktailSearchResultDto>(json, opts);
            return dto;
        }

        public async Task<DrinkDto?> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            var url = $"{BaseUrl}lookup.php?i={Uri.EscapeDataString(id)}";
            var resp = await _http.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;
            var json = await resp.Content.ReadAsStringAsync();
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dto = JsonSerializer.Deserialize<CocktailSearchResultDto>(json, opts);
            return dto?.drinks?.FirstOrDefault();
        }
    }
}
