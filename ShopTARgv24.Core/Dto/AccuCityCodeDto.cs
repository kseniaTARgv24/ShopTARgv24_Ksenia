using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv24_Ksenia.Core.Dto
{
    public class AccuCityCodeDto
    {
        public int version { get; set; }
        public string? key { get; set; }

        public string? type { get; set; }
        public string? rank { get; set; }
        public string? localizedName { get; set; }
        public string? englishName { get; set; }
        public string? primaryPostalCode { get; set; }
        public string? region { get; set; }
        public string? country { get; set; }
        public string? administrativeArea { get; set; }
        public string? timeZone { get; set; }
        public string? geoPosition { get; set; }
        public bool? isAlias { get; set; }
        public List<string>? dataSets { get; set; }
    }

    public class Region
    {
        public string? ID { get; set; }
        public string? localizedName { get; set; }
        public string? englishName { get; set; }
    }

    public class Country
    {
        public string? ID { get; set; }
        public string? localizedName { get; set; }
        public string? englishName { get; set; }
    }

    public class AdministrativeArea
    {
        public string? ID { get; set; }
        public string? localizedName { get; set; }
        public string? englishName { get; set; }
        public int level { get; set; }
        public string? localizedType { get; set; }
        public string? englishType { get; set; }
        public string? countryID { get; set; }
    }

    public class TimeZone
    {
        public string? code { get; set; }
        public string? name { get; set; }
        public double? gmtOffset { get; set; }
        public bool isDaylightSaving { get; set; }
        public string? nextOffsetChange { get; set; }

    }

    public class GeoPosition
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int elevation { get; set; }
    }

    public class Elevation
    {
        public Metric_Imperial? metric { get; set; }
        public Metric_Imperial? imperial { get; set; }
    }

    public class Metric_Imperial
    {
        public double value { get; set; }
        public string? unit { get; set; }
        public int unitType { get; set; }
    }

}
