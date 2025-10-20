﻿using Microsoft.AspNetCore.Mvc;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;
using ShopTARgv24_Ksenia.Models.Weather;

namespace ShopTARgv24_Ksenia.Controllers
{
    public class WeatherController : Controller
    {
        readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherController
            (
                IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            AccuLocationWeatherResultDto dto = new();
            dto.CityName = city;

            _weatherForecastServices.AccuWeatherResult(dto);

            AccuWeatherViewModel vm = new();

            vm.TempMetricValueUnit = dto.TempMetricValueUnit;
            vm.Text = dto.Text;
            vm.EndDate = dto.EndDate;

            return View(vm);
        }

    }
}
