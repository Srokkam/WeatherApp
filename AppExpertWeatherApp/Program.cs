using System;
using System.Threading;
using System.Threading.Tasks;
using AppExpertWeatherApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Providers;

namespace AppExpertWeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Added Depedency Injection 
            var serviceProvider = new ServiceCollection()
           .AddSingleton<IWeatherService, WeatherService>()
           .AddSingleton<ApiClient>()
           .BuildServiceProvider();

            var weatherReportService = serviceProvider.GetService<IWeatherService>();
            WeatherDetail data = new WeatherDetail();
            
            Parallel.Invoke(() => { data = weatherReportService.GetWeatherReport(); }, () => Console.WriteLine("Open Weather Client"));

            Console.WriteLine("City " + data.Name);
            Console.WriteLine("Temp " + (data.weather.Temp - 273.15).ToString("0.##") + " Celsius");
            Console.WriteLine("Feels Like " + (data.weather.TempLike - 273.15).ToString("0.##") + " Celsius");
            Console.WriteLine("Pressure " + data.weather.Pressure + " hPa");
            Console.WriteLine("Humidity " + data.weather.Humidity + " %");
        }
     }
  
}

