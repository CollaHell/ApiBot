using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
namespace ApiBot.Models.Bot
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract Task Execute(ResponseInfo.Result message, TelegramBotClient client);
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }
    }
}