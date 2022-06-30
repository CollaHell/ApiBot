using Telegram.Bot;
using System.Net.Http;
using ApiBot.Models.Bot;
using System.Threading.Tasks;
using ApiBot.Help_tools;
using Telegram.Bot.Types;
using System.Collections.Generic;
namespace ApiBot.Commands.Bot
{
    public class DeleteSubscribe : Command
    {
        public override string Name => "updatesubscribe";
        public override async Task Execute(ResponseInfo.Result message, TelegramBotClient client)
        {
            var chatId = message.Message.Chat.Id;
            var messageId = message.Message.Message_Id;
            var messageText = message.Message.Text;

            messageText = Helper.CommandRemover(messageText, Name);
            var clt = new HttpClient();

            if (string.IsNullOrWhiteSpace(messageText))
            {
                string b = $"https://ik11currencyexchange.azurewebsites.net/api/subscribe/DeleteSubscription/{chatId}";

                string d = $"https://ik11currencyexchange.azurewebsites.net/api/subscribe/DeleteSubscription/{chatId}";
                await clt.PutAsync(d, null);
                await client.SendTextMessageAsync(chatId, "Deleted");

                return;
            }

         
            string s = $"https://ik11currencyexchange.azurewebsites.net/api/subscribe/UpdateSubscription/{chatId}/{messageText}";
            var resp = clt.PutAsync(s, null);

            await client.SendTextMessageAsync(chatId, "Updated"); 
        }
    }
}