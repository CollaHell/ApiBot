using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiBot.Models.Bot;
using ApiBot.Models;
using ApiBot.Commands;
using Telegram;
using Telegram.Bot;
using Telegram.Bot.Types;
namespace ApiBot.Controllers.Bot
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<OkResult> Update(ResponseInfo.Result update)
        {
            if (update == null) return Ok();

            var commands = ApiBot.Models.Bot.Bot.Commands;
            var message = update.Message;
            var client = await Models.Bot.Bot.Get();

            if (message.Text == null)
            {

                
                return Ok();
                
            }


            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {

                    await command.Execute(update, client);
                    return Ok();
                }
            }

            return Ok();
        }
    }
}
