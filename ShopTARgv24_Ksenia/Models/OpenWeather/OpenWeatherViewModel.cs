namespace ShopTARgv24_Ksenia.Models.OpenWeather
{
    public class OpenWeatherViewModel
    {
        public string? CityName { get; set; } = string.Empty;
        public string? RegionName { get; set; } = string.Empty;
        public float? Temperature { get; set; }
        public string? WeatherName { get; set; } = string.Empty;
        public string? WeatherDescription { get; set; } = string.Empty;
        public string? WeatherIcon { get; set; } = string.Empty;
        public float? FeelsLike { get; set; }
        public float? Temp_Min_Max { get; set; }
        public int? Humidity { get; set; }
        public string? Pressure { get; set; } = string.Empty;
        public float? WindSpeed { get; set; }
        public string? Sunrise { get; set; } = string.Empty;
        public string? Sunset { get; set; } = string.Empty;

    }
}
