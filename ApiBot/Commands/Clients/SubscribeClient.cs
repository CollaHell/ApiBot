using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
namespace ApiBot.Clients
{

    public class SubscribeClient
    {
        private HttpClient _client;
        private static string _adress;
        private static string _user;
        private static string _password;
        private string connection;


        private static string _apikey;

        public SubscribeClient()
        {
            _adress = Constants.adress;
            _apikey = Constants.apikey;
            _user = Constants.user_id;
            _password = Constants.password;
            //todo caption 
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
            connection = $"Server=tcp:databasecrncy.database.windows.net,1433;Initial Catalog=subscribe;Persist Security Info=False;User ID={_user};Password={_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public async Task<double> GetGDP(string code)
        {
            double c = 1;
            using (SqlConnection con = new SqlConnection(connection))
            {

                await con.OpenAsync();
                SqlCommand command = new SqlCommand();
                //       Sqlcomma    command = new SqliteCommand();
                //       command.Connection = sqlite_conn;
                command.Connection = con;
                command.CommandText = $"SELECT GDP FROM macroeconomic WHERE COUNTRY = @codes";
                command.Parameters.AddWithValue("@codes", code);

                SqlDataReader sdr = await command.ExecuteReaderAsync();

                while (await sdr.ReadAsync())
                {
                    c = Convert.ToDouble(sdr["GDP"]);

                }

                await con.CloseAsync();
                return c;

            }
        }
        public async Task AddSubscribe(long user_id, string codes)
        {

            // SqliteConnection sqlite_conn = new SqliteConnection("Data Source=subsribe.db");
            using (SqlConnection con = new SqlConnection(connection))
            {

                await con.OpenAsync();

                SqlCommand command = new SqlCommand();
                //       Sqlcomma    command = new SqliteCommand();
                //       command.Connection = sqlite_conn;
                command.Connection = con;
                command.CommandText = $"INSERT INTO subscription VALUES(@user_id,@codes,@sub)";
                command.Parameters.AddWithValue("@user_id", user_id);
                command.Parameters.AddWithValue("@codes", codes);
                command.Parameters.AddWithValue("@sub", 0);


                await command.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }

        public async Task DeleteSubscribe(long user_id)
        {

            // SqliteConnection sqlite_conn = new SqliteConnection("Data Source=subsribe.db");
            using (SqlConnection con = new SqlConnection(connection))
            {

                await con.OpenAsync();
                SqlCommand command = new SqlCommand();
                //       Sqlcomma    command = new SqliteCommand();
                //       command.Connection = sqlite_conn;
                command.Connection = con;
                command.CommandText = $"DELETE FROM subscription WHERE USER_ID = @user_id";
                command.Parameters.AddWithValue("@user_id", user_id);
                await command.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }

        public async Task AddWallet()
        {
            await Models.Bot.Bot.client.SendTextMessageAsync("469786283", " hello ");

        }
        public async Task UpdateSubscribe(long user_id, string codes)
        {

            // SqliteConnection sqlite_conn = new SqliteConnection("Data Source=subsribe.db");
            using (SqlConnection con = new SqlConnection(connection))
            {

                await con.OpenAsync();
                SqlCommand command = new SqlCommand();
                //       Sqlcomma    command = new SqliteCommand();
                //       command.Connection = sqlite_conn;
                command.Connection = con;
                command.CommandText = $"UPDATE [dbo].[subscription] SET CURRENCY = @codes WHERE USER_ID = @user_id";
                command.Parameters.AddWithValue("@codes", codes);
                command.Parameters.AddWithValue("@user_id", user_id);
                await command.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }


        public async Task<string> GetSubscriptions(long user_id)
        {
            
            string c = "";
            HttpClient client = new HttpClient();
           
            // SqliteConnection sqlite_conn = new SqliteConnection("Data Source=subsribe.db");
            using (SqlConnection con = new SqlConnection(connection))
            {

                await con.OpenAsync();
                SqlCommand command = new SqlCommand();
                //       Sqlcomma    command = new SqliteCommand();
                //       command.Connection = sqlite_conn;
                command.Connection = con;
                command.CommandText = $"SELECT CURRENCY FROM subscription WHERE USER_ID = @user_id";
                command.Parameters.AddWithValue("@user_id", user_id);

                SqlDataReader sdr = command.ExecuteReader();

                while (await sdr.ReadAsync())
                {
                    c = (string)sdr["currency"];


                }
                var ar = c.Split(" ");
                c = "";
                Models.Root2 mc;
                foreach(var cur in ar)
                {
                    try
                    {
                        var resp = client.GetAsync($"http://ik11currencyexchange.azurewebsites.net/api/currency/GetCurrencyExchange/{cur}/USD").Result;
                        var result = await resp.Content.ReadAsStringAsync();
                        // var j = JsonConvert.SerializeObject(result);
                        mc = JsonConvert.DeserializeObject<Models.Root2>(result);
                        c += "From: " + mc.RealtimeCurrencyExchangeRate._2FromCurrencyName + " to: " + mc.RealtimeCurrencyExchangeRate._4ToCurrencyName + " Exchange: " + mc.RealtimeCurrencyExchangeRate._5ExchangeRate + '\n';
                    }
                    catch
                    {

                    }


                }

                await Models.Bot.Bot.client.SendTextMessageAsync(user_id, c);

                await con.CloseAsync();
            }

            return c;
        }
        public async Task GetSubs()
        {
            string m = "";
            HttpClient client = new HttpClient();
            long c1;
            string c2;
            // SqliteConnection sqlite_conn = new SqliteConnection("Data Source=subsribe.db");

            using (SqlConnection con = new SqlConnection(connection))
            {

                await con.OpenAsync();
                SqlCommand command = new SqlCommand();
                //       Sqlcomma    command = new SqliteCommand();
                //       command.Connection = sqlite_conn;
                command.Connection = con;
                command.CommandText = $"SELECT * FROM subscription WHERE FLAG = 1";
                SqlDataReader sdr = command.ExecuteReader();

                while (await sdr.ReadAsync())
                {

                    c1 = (long)sdr["user_id"];
                    c2 = (string)sdr["currency"];
                    await GetSubscriptions(c1);
                }
                await con.CloseAsync();


            }

        }


    }
}