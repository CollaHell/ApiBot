using System;
using ApiBot;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ApiBot.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class RealtimeCurrencyExchangeRate
    {
        [JsonProperty("1. From_Currency Code")]
        public string _1FromCurrencyCode { get; set; }

        [JsonProperty("2. From_Currency Name")]
        public string _2FromCurrencyName { get; set; }

        [JsonProperty("3. To_Currency Code")]
        public string _3ToCurrencyCode { get; set; }

        [JsonProperty("4. To_Currency Name")]
        public string _4ToCurrencyName { get; set; }

        [JsonProperty("5. Exchange Rate")]
        public string _5ExchangeRate { get; set; }

        [JsonProperty("6. Last Refreshed")]
        public string _6LastRefreshed { get; set; }

        [JsonProperty("7. Time Zone")]
        public string _7TimeZone { get; set; }

        [JsonProperty("8. Bid Price")]
        public string _8BidPrice { get; set; }

        [JsonProperty("9. Ask Price")]
        public string _9AskPrice { get; set; }
    }

    public class Root
    {
        [JsonProperty("Realtime Currency Exchange Rate")]
        public RealtimeCurrencyExchangeRate RealtimeCurrencyExchangeRate { get; set; }
    }

    public class CurExc
    {
        public string _1FromCurrencyCode { get; set; }

        public string _2FromCurrencyName { get; set; }

        public string _3ToCurrencyCode { get; set; }

        public string _4ToCurrencyName { get; set; }

        public string _5ExchangeRate { get; set; }

        public string _6LastRefreshed { get; set; }

        public string _7TimeZone { get; set; }

        public string _8BidPrice { get; set; }

        public string _9AskPrice { get; set; }
    }

    public class Root2
    {
        public CurExc RealtimeCurrencyExchangeRate { get; set; }
    }

    public class RootRoot
    {
        public Root Root { get; set; }
    }


}
