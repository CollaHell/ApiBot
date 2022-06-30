using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiBot.Models;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ApiBot;
using ApiBot.Clients;
namespace ApiBot.Controllers
{
    [ApiController]

    [Route("api/[controller]/[action]")]
    public class CurrencyController : Controller
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly Clients.CurrencyClient _currencyClient;
        public CurrencyController(ILogger<CurrencyController> logger, Clients.CurrencyClient currencyClient)
        {
            _logger = logger;
            _currencyClient = currencyClient;
        }

        [HttpGet("{code1}/{code2}")]

        public async Task<Models.Root> GetCurrencyExchange(string code1, string code2)
        {
            //
            string from = code1;
            string to = code2;

        //    await _currencyClient.AddSubscribe(1, "uah");
        


            var exchange = await _currencyClient.GetCurrencyExchange(from, to);
            return exchange;
        }

       


    }
}
