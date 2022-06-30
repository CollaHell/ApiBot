using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;
using Microsoft.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ApiBot.Clients
{

    public class CurrencyClient
    {
        private HttpClient _client;
        private static string _adress;




        private static string _apikey;

        public CurrencyClient()
        {
            _adress = Constants.adress;
            _apikey = Constants.apikey;
            //todo caption 
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);

        }

        public async Task<Models.Root> GetCurrencyExchange(string from, string to)
        {
            from = from.ToUpper();
            to = to.ToUpper();

            var response = await _client.GetAsync($"https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={from}&to_currency={to}&apikey={_apikey}");


            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Models.Root>(content);
            //convert  to json

            return result;
        }



      
    }
}