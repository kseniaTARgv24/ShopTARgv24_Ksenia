using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv24_Ksenia.Core.Dto
{
    public class AccuLocationRootDto
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; } = string.Empty;
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string? PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public AccuTemperatureDto? Temperature { get; set; } = new AccuTemperatureDto();
        public string? MobileLink { get; set; }
        public string? Link { get; set; }

    }

    public class AccuTemperatureDto
    {
        public WeatherValueDto? Metric { get; set; } 
        public WeatherValueDto? Imperial { get; set; }
    }

    public class WeatherValueDto
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }



}
