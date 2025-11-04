using Microsoft.AspNetCore.Mvc;
using ShopTARgv24_Ksenia.Core.ServiceInterface;
using ShopTARgv24_Ksenia.Models.OpenWeather;

namespace ShopTARgv24_Ksenia.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        public OpenWeatherController(IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchCity(OpenWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return await GetWeather(model.CityName);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(string? CityName)
        {
            var dto=await _openWeatherServices.OpenWeatherResult(CityName ?? string.Empty);
            var model = new OpenWeatherViewModel
            {
                CityName = dto.name,
                RegionName = dto.sys?.country,
                Temperature = dto.main?.temp,
                FeelsLike = dto.main?.feels_like,
                Temp_Min_Max = dto.main != null ? (dto.main.temp_min + dto.main.temp_max) / 2 : null,
                Humidity = dto.main?.humidity,
                Pressure = dto.main != null ? $"{dto.main.pressure} hPa" : string.Empty,
                WindSpeed = dto.wind?.speed,
                WeatherName = dto.weather?.FirstOrDefault()?.main,
                WeatherDescription = dto.weather?.FirstOrDefault()?.description,
                WeatherIcon = dto.weather?.FirstOrDefault()?.icon,
                Sunrise = dto.sys != null ? UnixTimeToLocal(dto.sys.sunrise, dto.timezone) : string.Empty,
                Sunset = dto.sys != null ? UnixTimeToLocal(dto.sys.sunset, dto.timezone) : string.Empty
            };

            return View("CityForecast", model);

        }

        private string UnixTimeToLocal(int unixTime, int timezoneOffset)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTime).ToOffset(TimeSpan.FromSeconds(timezoneOffset));
            return dateTimeOffset.ToString("HH:mm");
        }

    }
}
