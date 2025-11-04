using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;

namespace ShopTARgv24_Ksenia.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        private readonly HttpClient _http;
        private readonly string apikey = "ad699eafef404b9c5913ef1faaee4e00";
        public OpenWeatherServices(HttpClient http)
        {
            _http = http;
        }

        //https://api.openweathermap.org/data/2.5/weather?q=Tallinn&appid=ad699eafef404b9c5913ef1faaee4e00
        public async Task<OpenWeatherDto?> OpenWeatherResult(string CityName)
        {
            if (string.IsNullOrWhiteSpace(CityName)) return null;

            var q = Uri.EscapeDataString(CityName.Trim());
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={q}&appid={apikey}&units=metric";

            var resp = await _http.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;
            var json = await resp.Content.ReadAsStringAsync();
            var opts = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dto = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherDto>(json, opts);
            return dto;
        }
    }
}
