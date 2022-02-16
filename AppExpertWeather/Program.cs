using System;
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

            Console.WriteLine("Open Weather Client");
            var weatherReportService = serviceProvider.GetService<IWeatherService>();

            Parallel.Invoke(() => {
                City city = new City("Montreal","CA");
                PrintData(weatherReportService.GetWeatherReport(city)); 

            }, 
            () => {
                
                  City city = new City("Kolkata", "IN");
                PrintData(weatherReportService.GetWeatherReport(city));

            });

           
        }
        public static void PrintData(WeatherDetail data)
        {
            Console.WriteLine("City :" + data.Name);
            Console.WriteLine("Temp At "+data.Name+":" + (data.weather.Temp - 273.15).ToString("0.##") + " Celsius");
            Console.WriteLine(data.Name+" Feels Like :" + (data.weather.TempLike - 273.15).ToString("0.##") + " Celsius");
            Console.WriteLine("Pressure At " + data.Name + ":" + data.weather.Pressure + " hPa");
            Console.WriteLine("Humidity At " + data.Name + ":" + data.weather.Humidity + " %");
        }
    }

}

