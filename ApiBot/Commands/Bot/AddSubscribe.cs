using Telegram.Bot;
using System.Net.Http;
using ApiBot.Models.Bot;
using System.Threading.Tasks;
using ApiBot.Help_tools;
using Telegram.Bot.Types;
namespace ApiBot.Commands.Bot
{
    public class AddSubscribe : Command
    {
        public override string Name => "addsubscribe";
        public override async Task Execute(ResponseInfo.Result message, TelegramBotClient client)
        {
            
            var chatId = message.Message.Chat.Id;
            var messageId = message.Message.Message_Id;
            var messageText = message.Message.Text;

            messageText = Helper.CommandRemover(messageText, Name);
            if (string.IsNullOrWhiteSpace(messageText))
            {
                await client.SendTextMessageAsync(chatId, "No Content Added", replyToMessageId: messageId);
                return;
            }

            var clt = new HttpClient();
            string s = $"https://ik11currencyexchange.azurewebsites.net/api/subscribe/AddSubscription/{chatId}/{messageText}";
            var resp = await clt.PostAsync(s, null);

            await client.SendTextMessageAsync(chatId, "Done");
        }
    }
}