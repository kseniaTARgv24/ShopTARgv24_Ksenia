using Microsoft.AspNetCore.Mvc;
using ShopTARgv24_Ksenia.Core.ServiceInterface;

namespace ShopTARgv24_Ksenia.Controllers
{
    public class WeatherController : Controller
    {
        readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherController(IWeatherForecastServices weatherForecastServices) { 
                _weatherForecastServices = weatherForecastServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        //action SearchCity
        [HttpPost]
        public IActionResult SearchCity()
        {
            return View();
        }

    }
}
