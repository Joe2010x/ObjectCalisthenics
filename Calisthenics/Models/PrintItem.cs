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

        private string Handle(string input)
        {
            if(input.Length == 5)
            {
                return "";
            }
            var output = input.Substring(7, input.Length - 8);

            return output;
        }
    }
}