using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helpers
{
    public class RandomStringHelper
    {
        public static string GetRandomString(int length = 10)
        {
            var rand = new Random();
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            var upper = lower.ToUpper();
            const string num = "0123456789";
            var builder = new StringBuilder();
            for (var i = 0; i <= length; i++)
            {
                var input = $"{lower}{upper}{num}";
                var ch = input[rand.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
