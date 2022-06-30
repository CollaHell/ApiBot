using Telegram.Bot;
using System.Net.Http;
using ApiBot.Models.Bot;
using System.Threading.Tasks;
using ApiBot.Help_tools;
using Telegram.Bot.Types;
namespace ApiBot.Commands.Bot
{
    public class GetSubscribe : Command
    {
        public override string Name => "getsubscribe";
        public override async Task Execute(ResponseInfo.Result message, TelegramBotClient client)
        {

            var chatId = message.Message.Chat.Id;
            var messageId = message.Message.Message_Id;
            var messageText = message.Message.Text;
            try
            {
                var clt = new HttpClient();
                string s = $"https://ik11currencyexchange.azurewebsites.net/api/subscribe/GetSubscriptions/{chatId}";
                var resp = await clt.GetAsync(s);
            }
            catch
            {
                await client.SendTextMessageAsync(chatId, "Error occured");

            }
        }
    }
}