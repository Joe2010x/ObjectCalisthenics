using System;
using System.Collections.Generic;
using System.Linq;

namespace Calisthenics.Models
{
    public class PrintItem
    {
        public string content;

        public List<string[]> variable {get; set;}

        public PrintItem(string input,List<string[]> inputVariable)
        {

            variable = inputVariable;
            content = Handle(input);
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

                return input;

            }
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
            //Hanle single variable        
            return HandleNumericalSum(printInput).ToString();

        }
        public int HandleNumericalSum(string input)
        {

            input = input.Replace(" ", String.Empty);

            // handle empty input
            if (input.Length==0) return 0;

            var operators = new char[] {'+','-','(',')'};

            // handle +
            if (input[0]== operators[0])
                return HandleNumericalSum(input.Substring(1,input.Length-1));

            // handle -
            if (input[0]== operators[1])           
                return - HandleNumericalSum(FirstElement(input.Substring(1,input.Length-1))) + HandleNumericalSum(RestOfInput(input.Substring(1,input.Length-1)));

            // handle with number and variable
            if (input.IndexOfAny(operators) == -1)
                if (int.TryParse(input,out var num))
                    return num;
                else    
                    return GetValue(input, variable);
            else 
                return HandleNumericalSum(FirstElement(input)) + HandleNumericalSum(RestOfInput(input));            
        }

        private string RestOfInput(string input)
        {
            if (input.Length == 0) return "";
            var startIndex = input.IndexOfAny(new char[] {'-','+'}) ;
            if (input[0]=='(')
                startIndex = input.IndexOf(')') + 1;
            if (startIndex == -1 ) return "";
            return input.Substring(startIndex,input.Length-startIndex);
        }

        private string FirstElement(string input)
        {
            if (input.Length == 0) return "";
            var endIndex = input.IndexOfAny(new char[] {'-','+'});
            if (input[0]=='(')
            {
                endIndex = input.IndexOf(')') ;
                return input.Substring(1,endIndex-1);
            }                    
            if (endIndex == -1 ) return input;
            return input.Substring(0,endIndex);
        }

        private int GetValue(string input, List<string[]> variable)
        {
            //throw new NotImplementedException();

            var result = variable.Where(v => v[0] == input).FirstOrDefault();

            if (result== null)
                return 0;
            
            return int.Parse(result[1]);
        }


    }
}