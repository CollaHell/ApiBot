using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBot.Models.Bot
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://ik11currencyexchange.azurewebsites.net:443/"; //azure deploy
        public static string Name { get; set; } = "CurrencyBot";
        
        public static string Key { get; set; } = "5311264525:AAFsLN7w3wg_DZrJ-S_k8M3kgyONtv9ZgIM"; //bot api key
    }
}
