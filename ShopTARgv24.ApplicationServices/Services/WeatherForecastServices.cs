using System.Text.Json;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;

namespace ShopTARgv24_Ksenia.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "zpka_80d3f6a9d8324c93949a4a372495df05_58d08c6e"; // Replace with your actual API key
            string baseUrl = "http://dataservice.accuweather.com/locations/v1/cities/search";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //var response = await httpClient.GetAsync($"{127964}?apikey={accuApiKey}&details=true");
                var response = await httpClient.GetAsync($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey={accuApiKey}&details=true&metric=true");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);

                    var weatherData = JsonSerializer.Deserialize<AccuLocationRootDto>(jsonResponse);


                    dto.EndDate = weatherData.Headline.EndDate;
                    dto.Text = weatherData.Headline.Text;
                    dto.TempMetricValueUnit = weatherData.DailyForecasts[0].Temperature.Maximum.Value;

                    return dto;
                }
                else
                {
                    // Handle error response
                    throw new Exception("Error fetching weather data from AccuWeather API");
                }
            }

        }


    }
}
