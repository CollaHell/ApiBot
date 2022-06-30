using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using ApiBot.Models;

namespace ApiBot.Models.Bot
{
    public static class Bot
    {
        public static TelegramBotClient client;
        private static List<Command> commandlist;
        public static IReadOnlyList<Command> Commands { get => commandlist.AsReadOnly(); }
        public static async Task<TelegramBotClient> Get()
        {       
            commandlist = new List<Command>();
            commandlist.Add(new Commands.Bot.GetGDP());
            commandlist.Add(new Commands.Bot.GetExchange());
            commandlist.Add(new Commands.Bot.AddSubscribe());
            commandlist.Add(new Commands.Bot.DeleteSubscribe());
            commandlist.Add(new Commands.Bot.Start());
            commandlist.Add(new Commands.Bot.Help());
            commandlist.Add(new Commands.Bot.GetSubscribe());

            if (client != null)
            {
                return client;
            }

            //не забути добавити всі команди сюди

            client = new TelegramBotClient(AppSettings.Key);

            var hook = string.Concat(AppSettings.Url, "api/message/Update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}
