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
using System.Data.SqlClient;
using ApiBot.Models.Bot;
using Telegram.Bot;
namespace ApiBot.Controllers
{
    [ApiController]

    [Route("api/[controller]/[action]")]
    public class SubscribeController : Controller
    {
        private readonly ILogger<SubscribeController> _logger;
        private readonly Clients.SubscribeClient _subscribeClient;
        public SubscribeController(ILogger<SubscribeController> logger, Clients.SubscribeClient subscribeClient)
        {
            _logger = logger;
            _subscribeClient = subscribeClient;
        }



        [HttpPut("{user_id}")]
        public async Task DeleteSubscription(int user_id)
        {
            await _subscribeClient.DeleteSubscribe(user_id);

        }

        [HttpPut("{user_id}/{codes}")]
        public async Task UpdateSubscription(int user_id, string codes)
        {
            await _subscribeClient.UpdateSubscribe(user_id, codes);

        }

        [HttpGet("{user_id}")]
        public async Task<string> GetSubscriptions(int user_id)
        {
            string c = await _subscribeClient.GetSubscriptions(user_id);
            return c;
        }

        [HttpGet]
        public async Task GetSubs()
        {
            await _subscribeClient.GetSubs();

        }

        [HttpGet("{code}")]
        public async Task<double> GetGdp(string code)
        {
            double c = await _subscribeClient.GetGDP(code);

            return c;
        }


        [HttpPost("{user_id}/{codes}")]
        public async Task<OkResult> AddSubscription(long user_id, string codes)
        {
            await _subscribeClient.AddSubscribe(user_id, codes);
            return Ok();
        }

        [HttpPost]
        public async Task GetWallet()
        {
            try
            {
                await _subscribeClient.GetSubs();
            }
            catch { }

        }


    }
}
