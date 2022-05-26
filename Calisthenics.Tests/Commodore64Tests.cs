using System;
using Xunit;
using FluentAssertions;
using Calisthenics.Models;

namespace Calisthenics.Tests
{
    public class Commodore64Tests
    {
        [Fact]
        public void interpret_method_when_empty_input_should_return_empty()
        {
            //arrange
            var commodore64 = new Commodore64();

            //act
            var result = commodore64.Interpret();

            //assert
            result.Should().Be(null);
        }

        [Fact]
        public void interpret_method_when_input_should_return_input()
        {
            //arrange
            var input = "PRINT";
            var commodore64 = new Commodore64(input);

            //act
            var result = commodore64.Interpret();

            //assert
            result.Should().Be("\n");
        }

        [Fact]
        public void interpret_should_return_hello_comma_world()
        {
            //arrange
            var input = "PRINT \"Hello, World!\"";
            var commodore64 = new Commodore64(input);

            //act
            var result = commodore64.Interpret();

            //assert
            result.Should().Be("Hello, World!");
        }

        [Fact]
        public void interpret_should_handle_sequence_of_input()
        {
            //arrange
            var input = "PRINT \"Hi\"\nPRINT \"There\"\nPRINT \"!\"";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("Hi\nThere\n!");
        }

        [Fact]
        public void interpret_should_return_numeric_string()
        {
            //arrange
            var input = "PRINT 123";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("123");
            
        }

         [Fact]
        public void interpret_should_return_numeric_string_minus_3()
        {
            //arrange
            var input = "PRINT -3";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("-3");
            
        } 
        
        [Fact]
        public void interpret_should_add_numbers()
        {
            //arrange
            var input = "PRINT 3 + 7";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("10");
            
        }
          [Fact]
        public void interpret_should_add_multiple_numbers()
        {
            //arrange
            var input = "PRINT 4 + 4 + 12";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("20");
            
        }
        [Fact]
        public void interpret_should_add_multiple_and_substract_numbers()
        {
            //arrange
            var input = "PRINT 1 - 4 + 12";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("9");
            
        }
        [Fact]
        public void interpret_should_handle_simple_assignment()
        {
            //arrange
            var input = "A=12\nC=20\nPRINT D";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("20");
            
        }

         [Fact]
        public void interpret_should_handle_simple_assignment_should_return_12()
        {
            //arrange
            var input = "A=12\nC=20\nPRINT C";
            //var commodore64 = new Commodore64(input);
            var printItems = new PrintItems(input);
            //act
            //var result = commodore64.Interpret();

            //assert
            printItems.variable[0][0].Should().Be("A");
            
        }

        [Fact]
        public void interpret_should_handle_multiple_assignment_should_return_12()
        {
            //arrange
            var input = "A=2\nB=7\nPRINT A + 1\nPRINT A + B\nPRINT 99 + B";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();

            //assert
            result.Should().Be("3\n9\n106");
            
        }

        [Fact]
        public void interpret_should_work_with_bracket_100()
        {
            //arrange
            var input = "PRINT  (123 -100 )-(8-5)+80";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("100");
        }
        [Fact]
        public void interpret_should_work_with_bracket_1x0()
        {
            //arrange
            var input = "PRINT  346-314-(9-7)+270+(52-403)";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("-100");
        }

         [Fact]
        public void interpret_should_work_with_bracket_3()
        {
            //arrange
            var input = "PRINT  -(8 - 5)";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("-3");
        }

         [Fact]
        public void interpret_should_work_with_bracke_3()
        {
            //arrange
            var input = "PRINT  (8 - 5)";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("3");
        }

         [Fact]
        public void interpret_should_work_with_bracket_positive_3()
        {
            //arrange
            var input = "PRINT  3";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("3");
        }

         [Fact]
        public void interpret_should_work_with_bracke_negative_3()
        {
            //arrange
            var input = "PRINT  -3";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("-3");
        }
         [Fact]
        public void interpret_should_work_with_bracke_positive_13()
        {
            //arrange
            var input = "PRINT  10+3";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("13");
        }
         [Fact]
        public void interpret_should_work_with_bracke_negative_13()
        {
            //arrange
            var input = "PRINT  0-13";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("-13");
        }
    }
}
