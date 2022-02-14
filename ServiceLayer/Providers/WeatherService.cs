using AppExpertWeatherApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Providers
{
    //Added service layer 
    public class WeatherService : IWeatherService
    {
        private ApiClient client;
        public WeatherService(ApiClient client)
        {
            this.client = client;
        }
        public WeatherDetail GetWeatherReport()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WeatherDetailDTO, WeatherDetail>();
                cfg.CreateMap<WeatherDTO, Weather>();
            });
            var mapper = new Mapper(config);

            string url = Constant.APIBase + "geo/1.0/direct?q=Montreal&limit=5&appid="+Constant.AppId;
            var data = client.GetTAsync<List<CityDTO>>(url).Result;
            var montrealData = data.Where(d => d.Country == "CA").FirstOrDefault();
            string weatherUrl = String.Format("{0}/data/2.5/weather?lat={1}&lon={2}&appid={3}", Constant.APIBase, montrealData.Lat, montrealData.Lon,Constant.AppId);
            
            return mapper.Map<WeatherDetail>(client.GetTAsync<WeatherDetailDTO>(weatherUrl).Result);
        }

    }
}
