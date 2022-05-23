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
            return input;
        }
    }
}