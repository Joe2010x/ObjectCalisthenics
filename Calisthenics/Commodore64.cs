using System;
using Calisthenics.Models;

namespace Calisthenics
{
    public class Commodore64
    {
        private InputWrapper _input;
        public Commodore64(string input = null)
        {
            _input = new InputWrapper(input);
        }

        public string Interpret()
        {
            if(_input.body != null && _input.body.Contains("PRINT"))
            {
                var printItem = new PrintItem(_input.body);
                return printItem.content;
            }

            return null;
        }

        public string HandlePrint(string input)
        {
            if (input.Length == 5)
            {
                return "\n";
            }

            var output = input.Substring(7, input.Length - 8);
            return output;
        }
    }
}