using System;
using System.Collections.Generic;

namespace Calisthenics.Models 
{
    public class PrintItems
    {
        public List<PrintItem> items;
        public Dictionary<string,int> variable;

        public PrintItems(string input)
        {
            items = ConvertToList(input);
        }

        public List<PrintItem> ConvertToList(string inputToConvert)
        {
            var result = new List<PrintItem>();

            foreach(var line in inputToConvert.Split("\n"))
            {
                var printItem = new PrintItem(line,variable);

                result.Add(printItem);
                variable = printItem.GetVariable();
            }
            return result;
        }

        public override string ToString()
        {
            var result = "";
            foreach(var content in items)
            {
                result += content.content + "\n";
            }

            return result.Substring(0, result.Length - 1);
        }
    }
}