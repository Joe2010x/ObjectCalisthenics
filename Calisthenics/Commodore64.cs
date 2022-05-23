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
                var printItems = new PrintItems(_input.body);
                return printItems.ToString();
            }

            return null;
        }
    }
}