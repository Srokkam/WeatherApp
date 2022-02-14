using AppExpertWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Providers
{
   public interface IWeatherService
    {
        WeatherDetail GetWeatherReport();
    }
}
