using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv24_Ksenia.Core.Dto
{
    public class AccuLocationWeatherResultDto
    {
        public string? CityName { get; set; } = string.Empty;
        public DateTime EndDate { get; set; } 
        public string? Text { get; set; } = string.Empty;

        public double TempMetricValueUnit { get; set; }
    }
}
