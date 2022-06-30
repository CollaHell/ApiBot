using System.Threading.Tasks;
using Telegram.Bot;
using ApiBot.Models.Bot;

namespace ApiBot.Commands.Bot
{
    public class Start : Command
    {
        public override string Name => "start";
        public override async Task Execute(ResponseInfo.Result message, TelegramBotClient client)
        {
            var chatId = message.Message.Chat.Id;
            var messageId = message.Message.Message_Id;

          
                string s = "Hello, user! To learn functionality use /help.";
                await client.SendTextMessageAsync(chatId, s);
            
           
          
        }
    }
}