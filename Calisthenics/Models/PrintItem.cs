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

        public Dictionary<string,int> variable {get; set;}

        public PrintItem(string input,Dictionary<string,int> inputVariable)
        {
            content = Handle(input);
            variable = inputVariable;
        }

        public Dictionary<string,int> GetVariable()
        {
            return variable;
        }

        public string Handle(string input)
        {
            // handle with "PRINT"
            if (input.Contains("PRINT"))
            {
                //handle empty input
                if (input.Length == 5) return "\n";
                
                return HandleWithPrint(input.Substring(6,input.Length-6));
            }
            else {

            // handle assignment, i.e. A=12
                if (input.Contains('='))
                    return "AssignmentExpression";

                return input;

            }
        }

        // public string HandleAssignment(string[] input)
        // {
        //    //variable.Add(input[0],int.Parse(input[1]));
        //     variable.Add("A",13);
        //     return "AssignmentExpression";
        // }


        public string HandleWithPrint(string printInput)
        {
            
            //Handle String
            if (printInput.Contains('"'))
                return printInput.Substring(1,printInput.Length-2);
            
            //Handle Digi
            if (int.TryParse(printInput,out var num))
                return num.ToString();

            
            //Handle multiple plus
            return HandleMultipleSum(printInput.Split('+',StringSplitOptions.TrimEntries).ToList());
            
            //Hanle single variable
            

            //return printInput;

        }

        private string HandleMultipleSum(List<string> multipleFactors)
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
                    if (factor.Contains("-"))
                        {
                            var substractionArray = factor.Split("-",StringSplitOptions.TrimEntries).ToList();
                            sum = sum+ int.Parse(substractionArray[0]) - int.Parse(HandleMultipleSum(substractionArray.RemoveAt(0)));
                        }
                }
            }
            return sum.ToString();
        }

    }
}