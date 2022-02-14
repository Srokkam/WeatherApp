using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppExpertWeatherApp.Models
{
    //Added DTOS
    public class CityDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
        
        [JsonPropertyName("state")]
        public string State { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

    }

    }

