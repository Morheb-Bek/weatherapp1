using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Weather
{
	[Route("api/[Controller]")]
	[ApiController]
	public class WeatherController : ControllerBase 
	{
		private IConfiguration configuration;

		public WeatherController(IConfiguration iConfig)
		{
			configuration = iConfig;

		}

		

		[HttpGet]
		[Route("{City}")]
		public async Task<ActionResult> WeatherAsync(string City)
		{
			WeatherGetter weatherGetter = new WeatherGetter();
			WeatherInfo weatherInfo = await weatherGetter.GetWeatherAsync(City, configuration);
			return Ok(weatherInfo);

		}

	}


	
}
