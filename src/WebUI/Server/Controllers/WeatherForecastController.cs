using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Maturnik.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Maturnik.WebUI.Shared.Models.WeatherForecast;

namespace Maturnik.WebUI.Server.Controllers
{
    [Authorize]
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var result = await Mediator.Send(new GetWeatherForecastsQuery());
            return result;
        }
    }
}
