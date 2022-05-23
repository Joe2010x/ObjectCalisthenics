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
            if (printInput.IndexOfAny(new char[] {'+','-','(',')'} ) != -1)
                return HandleNumericalSum(printInput).ToString();
            
            //Handle one variable
            if (variable!=null)
            {
                 if (variable.Find(v => v[0] == printInput).FirstOrDefault()!=null)
                return variable.Find(v => v[0] == printInput)[1].ToString();
            }
              
            //Hanle single variable
        
            return printInput;

        }
        public int HandleNumericalSum(string input)
        {
            input = input.Replace(" ", String.Empty);
            var operators = new char[] {'+','-','(',')'};

            if (input.Length==0) return 0;


            // handle ()
            var leftBracketIndex = input.IndexOf(operators[2]);
            if (leftBracketIndex != -1)
                {
                    var rightBracketIndex = input.IndexOf(operators[3]);
                    if (leftBracketIndex!=0)
                        {
                            var leftOperator = (input.Substring(0,leftBracketIndex-1));
                            var operatorSymbol = input.Substring(leftBracketIndex-1,1);
                            var bracketContent = (input.Substring(leftBracketIndex+1,rightBracketIndex-leftBracketIndex-1));
                            if (operatorSymbol=="+")
                                {
                                    return HandleNumericalSum(leftOperator) + HandleNumericalSum(bracketContent);
                                }
                                else 
                                {
                                    return HandleNumericalSum(leftOperator) - HandleNumericalSum(bracketContent);
                                }
                        }
                         
                }
            

            // handle + -
            var plusSymbolPosition = input.IndexOf("+");

            var minusSymbolPosition = input.IndexOf("-");

            if (plusSymbolPosition==-1 && minusSymbolPosition==-1)
            {

                //return int.Parse(input);
                if (int.TryParse(input,out var num))
                {
                    return num;
                }
                else {
                     if (variable!=null)
            {
                 if (variable.Find(v => v[0] == input).FirstOrDefault()!=null)
                return int.Parse(variable.Find(v => v[0] == input)[1]);
            }
                }

            }
            
            if (plusSymbolPosition!=-1)
                {
                    return HandleNumericalSum(input.Substring(0,plusSymbolPosition))+ HandleNumericalSum(input.Substring(plusSymbolPosition+1,input.Length-1-plusSymbolPosition));
                }
                else {
                    return HandleNumericalSum(input.Substring(0,minusSymbolPosition))-HandleNumericalSum(input.Substring(minusSymbolPosition+1,input.Length-minusSymbolPosition-1)) ;
                }

        }

        private string HandleMultipleSum(List<string> multipleFactors)
        {
            var sum = 0;
            
            return sum.ToString();
        }

    }
}