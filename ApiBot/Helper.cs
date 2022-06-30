using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ApiBot.Help_tools
{
    public class Helper
    {
        public static string Parser(string list, int num)
        {
            string[] ar = list.Split('\n');
            if (num > ar.Length || num < 1)
                return list;
            ar = ar.Where(val => val != ar[num - 1]).ToArray();
            list = String.Join("\n", ar);
            return list;
        }

        public static string QuotesRemover(string line)
        {
            Regex reg = new Regex(@"\[([\s\S]+?)\]");
            return reg.Replace(line, "");
        }

        public static string CommandRemover(string line, string command)
        {
            var s = $"/{command}\\s*";
            Regex reg = new Regex(s);
            return reg.Replace(line, "");
        }
    }
}