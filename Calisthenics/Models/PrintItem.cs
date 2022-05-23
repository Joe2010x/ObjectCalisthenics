using System;
using System.Collections.Generic;
using System.Linq;

namespace Calisthenics.Models
{
    public class PrintItem
    {
        public string content;
        public string key;
        public int value;

        private Dictionary<string,int> _variable {get; set;}

        public PrintItem(string input,Dictionary<string,int> variable)
        {
            content = Handle(input);
            _variable = variable;
        }

        public Dictionary<string,int> GetVariable()
        {
            return _variable;
        }

        public string Handle(string input)
        {
            // handle with "PRINT"
            if (input.Substring(0,5).Equals("PRINT"))
            {
                //handle empty input
                if (input.Length == 5) return "\n";
                
                return HandleWithPrint(input.Substring(6,input.Length-6));
            }
            else {

            // handle assignment, i.e. A=12
                if (input.Contains('='))
                    return HandleAssignment(input.Split('=',StringSplitOptions.TrimEntries));
                return input;

            }
        }

        public string HandleAssignment(string[] input)
        {
            _variable.Add(input[0],int.Parse(input[1]));
            return "AssignmentExpression";
        }


        public string HandleWithPrint(string printInput)
        {
            
            //Handle String
            if (printInput.Contains('"'))
                return printInput.Substring(1,printInput.Length-2);
            
            //Handle Digi
            if (int.TryParse(printInput,out var num))
                return num.ToString();

            
            //Handle multiple plus
            if (printInput.Contains("+"))
                return HandleMultipleSum(printInput.Split('+',StringSplitOptions.TrimEntries));
            
            //Hanle single variable
            Console.WriteLine(printInput);
            return _variable[printInput].ToString();

            //return printInput;

        }

        private string HandleMultipleSum(string[] multipleFactors)
        {
            var sum = 0;
            foreach (var factor in multipleFactors)
            {
                if (int.TryParse(factor, out var num) )
                {
                    sum += num;
                } 
                else 
                {
                    sum += _variable[factor];
                }
            }
            return sum.ToString();
        }

    }
}