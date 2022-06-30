using Telegram.Bot;
using System.Net.Http;
using ApiBot.Models.Bot;
using System.Threading.Tasks;
using ApiBot.Help_tools;
using Telegram.Bot.Types;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using ApiBot;
using ApiBot.Models;
using System;

namespace ApiBot.Commands.Bot
{
    public class GetGDP : Command
    {
        public override string Name => "getgdp";
        public override async Task Execute(ResponseInfo.Result message, TelegramBotClient client)
        {
            var chatId = message.Message.Chat.Id;
            var messageId = message.Message.Message_Id;
            var messageText = message.Message.Text;

            messageText = Helper.CommandRemover(messageText, Name);

            var clt = new HttpClient();
            var ap = new Random().Next().ToString();
            var order = chatId.ToString() + "_" + ap;
            string k = $"ik11currencyexchange_azurewebsites_net;https://ik11currencyexchange.azurewebsites.net;{order};5182022;1;UAH;Subscription;1;1";

            var l = new HMACMD5(new UTF8Encoding().GetBytes(Constants.merchantkey));
            byte[] hash = l.ComputeHash(new UTF8Encoding().GetBytes(k));

            var ls = BitConverter.ToString(hash).ToLower().Replace("-",string.Empty);
            var values = new Dictionary<string, string>
            {
                { "merchantAccount","ik11currencyexchange_azurewebsites_net"},
                { "merchantDomainName","https://ik11currencyexchange.azurewebsites.net"},
                { "merchantTransactionSecureType","AUTO"},
                { "merchantSignature",ls},
                { "orderReference",order},
                { "orderDate","5182022"},
                { "amount","1"},
                { "currency","UAH"},
                { "productName[]","Subscription"},
                { "productPrice[]","1"},
                { "productCount[]","1"},
                { "serviceUrl", "http://ik11currencyexchange.azurewebsites.net/api/subscribe/GetWallet/"}
            };

            var b = JsonConvert.SerializeObject(values);
            var d = new FormUrlEncodedContent(values);

            var u = clt.PostAsync("https://secure.wayforpay.com/pay?behavior=offline", d);
            string m = await u.Result.Content.ReadAsStringAsync();
            var url = JsonConvert.DeserializeObject<ResponseRoot>(m);
            await client.SendTextMessageAsync(chatId, url.Url);

            /*try
            {
                if (string.IsNullOrWhiteSpace(messageText))
                {
                    await client.SendTextMessageAsync(chatId, "NoContentAdded", replyToMessageId: messageId);
                    return;
                }

                var clt = new HttpClient();
                var resp = clt.GetAsync($"http://ik11currencyexchange.azurewebsites.net/api/subscribe/GetGdp/{messageText}").Result;
                var result = await resp.Content.ReadAsStringAsync();

                await client.SendTextMessageAsync(chatId, result);
            }
            catch
            {
                await client.SendTextMessageAsync(chatId, " Error occured, please check your input or try later");

            */
        }
    }
}