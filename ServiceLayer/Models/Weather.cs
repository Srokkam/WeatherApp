using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppExpertWeatherApp.Models
{
    public class CityWeatherDTO
    {
        [JsonPropertyName("temp")]

        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]

        public double TempLike { get; set; }
        [JsonPropertyName("pressure")]

        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

    }
    public class WeatherDTO
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double TempLike { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

    }

    public class Weather
    {
        public double Temp { get; set; }

        public double TempLike { get; set; }

        public double Pressure { get; set; }

        public double Humidity { get; set; }

    }

    public class WeatherDetailDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("main")]
        public WeatherDTO weather { get; set; }
    }

    public class WeatherDetail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("main")]
        public Weather weather { get; set; }
    }
}
