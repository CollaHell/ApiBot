using Telegram.Bot;
using System.Net.Http;
using ApiBot.Models.Bot;
using System.Threading.Tasks;
using ApiBot.Help_tools;
using ApiBot.Models;
using Telegram.Bot.Types;
using Newtonsoft.Json;
namespace ApiBot.Commands.Bot
{
    public class GetExchange : Command
    {
        public override string Name => "getexchange";
        public override async Task Execute(ResponseInfo.Result message, TelegramBotClient client)
        {
            var chatId = message.Message.Chat.Id;
            var messageId = message.Message.Message_Id;
            var messageText = message.Message.Text;
                     
            var codes = messageText.Split(" ");

            var clt = new HttpClient();
            try
            {

                var resp = clt.GetAsync($"http://ik11currencyexchange.azurewebsites.net/api/currency/GetCurrencyExchange/{codes[1]}/{codes[2]}").Result;
                var result = await resp.Content.ReadAsStringAsync();
                // var j = JsonConvert.SerializeObject(result);
                var cur = JsonConvert.DeserializeObject<Models.Root2>(result);

                var mes = "From: " + cur.RealtimeCurrencyExchangeRate._2FromCurrencyName + " to: " + cur.RealtimeCurrencyExchangeRate._4ToCurrencyName + " Exchange: " + cur.RealtimeCurrencyExchangeRate._5ExchangeRate;
                await client.SendTextMessageAsync(chatId, mes);
                string s = chatId + " " + codes[1] + " " + codes[2] + " " + codes[3];
                await clt.GetAsync("https://getimagecurrency.azurewebsites.net/api/GetExchange?name=" + s);

            }
            catch
            {


            }
            //  mes += "From: " + cur.RealtimeCurrencyExchangeRate._2FromCurrencyName + " To: " + cur.RealtimeCurrencyExchangeRate._4ToCurrencyName + " Rate: " + cur.RealtimeCurrencyExchangeRate._5ExchangeRate;
        }
    }
}