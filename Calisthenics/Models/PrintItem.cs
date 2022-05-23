using System;

namespace Calisthenics.Models
{
    public class PrintItem
    {
        public string content;

        public PrintItem(string input)
        {
            content = Handle(input);
        }

        public string Handle(string input)
        {
            if (input.Length == 5)
            {
                return "\n";
            }

            if(input.Contains('"'))
            {
                var output = input.Substring(7, input.Length - 8);

                return output;
            }

            return HandlesDigits(input);
        }

        private string HandlesDigits(string input)
        {
            var temp = "";
            foreach (var character in input)
            {
                if (Char.IsDigit(character))
                {
                    temp += character;
                }
            }
            return temp;
        }
    }
}