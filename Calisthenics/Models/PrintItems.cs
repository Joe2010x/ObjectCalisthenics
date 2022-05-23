using System;
using System.Collections.Generic;

namespace Calisthenics.Models 
{
    public class PrintItems
    {
        public List<PrintItem> items;
        public List<string[]> variable;

        public PrintItems(string input)
        {

            variable = new List<string[]>();
            items = ConvertToList(input);
        }

        public List<PrintItem> ConvertToList(string inputToConvert)
        {
            var result = new List<PrintItem>();

            foreach(var line in inputToConvert.Split("\n"))
            {
                if (line.Contains("PRINT"))
                {
                    var printItem = new PrintItem(line,variable);

                    result.Add(printItem);  
                }
                else {
                    var spliteLine = line.Split("=",StringSplitOptions.TrimEntries);
                    variable.Add(new string[] {spliteLine[0],spliteLine[1]});
                }
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