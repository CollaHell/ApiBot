using System;
using ApiBot;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ApiBot.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class WalletResponseRoot
    {
        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("orderReference")]
        public string OrderReference { get; set; }

        [JsonProperty("merchantSignature")]
        public string MerchantSignature { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("authCode")]
        public string AuthCode { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("createdDate")]
        public int CreatedDate { get; set; }

        [JsonProperty("processingDate")]
        public int ProcessingDate { get; set; }

        [JsonProperty("cardPan")]
        public string CardPan { get; set; }

        [JsonProperty("cardType")]
        public string CardType { get; set; }

        [JsonProperty("issuerBankCountry")]
        public string IssuerBankCountry { get; set; }

        [JsonProperty("issuerBankName")]
        public string IssuerBankName { get; set; }

        [JsonProperty("recToken")]
        public string RecToken { get; set; }

        [JsonProperty("transactionStatus")]
        public string TransactionStatus { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("reasonCode")]
        public string ReasonCode { get; set; }

        [JsonProperty("fee")]
        public int Fee { get; set; }

        [JsonProperty("paymentSystem")]
        public string PaymentSystem { get; set; }
    }



    public class ResponseRoot
    {
       
            [JsonProperty("url")]
            public string Url { get; set; }
        
    }

}
