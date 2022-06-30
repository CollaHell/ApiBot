using System.Threading.Tasks;
using Telegram.Bot;
using ApiBot.Models.Bot;

namespace ApiBot.Commands.Bot
{
    public class Help : Command
    {
        public override string Name => "help";
        public override async Task Execute(ResponseInfo.Result message, TelegramBotClient client)
        {
            var chatId = message.Message.Chat.Id;
            var messageId = message.Message.Message_Id;

            string s = "Information given below, describes the input features and command functionality.\n" +
                "Information in brackets [ ] is for additional information and seperated by space\n" +
                "You can see some examples in bot command menu\n"+
                "Command list:\n" +
                "/getgdp [alpha-3 code] — Get GDP by country\n" +
                "/getexchange [from to] — Get pair currency exchange\n" +
                "/addsubscribe [list of currency codes] - Add currency to your personal list\n" +
                "/updatesubscribe [list of currency codes or empy] - Changes your previous list to new, enter without string to delete your list\n" +
                "/getsubscribe - Get all your list exchanges with USD\n";


            await client.SendTextMessageAsync(message.Message.Chat.Id, s);
        }
    }
}