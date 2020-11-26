using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Weather
{
	public class WeatherGetter
	{
		private WeatherInfo weatherInfo = new WeatherInfo();
		public async Task<WeatherInfo> GetWeatherAsync(string City, IConfiguration configuration)
		{
			HttpClient httpClient = new HttpClient();
			string ApiCode = configuration["ApiCode"];
			var jsonText = await httpClient.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?q={City}&appid={ApiCode}&units=metric");
			var json = JObject.Parse(jsonText);
			double temp = json["main"]["temp"].Value<double>();
			String Discription = json["weather"][0]["description"].Value<string>();

			weatherInfo.City = City;
			weatherInfo.Condition = Discription;
			weatherInfo.Temperature = temp;
			return weatherInfo;
		}
	}
}
