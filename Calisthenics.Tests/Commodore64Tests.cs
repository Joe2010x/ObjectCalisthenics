using System;
using Xunit;
using FluentAssertions;

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
            var input = @"PRINT ""Hi""\nPRINT ""There""\nPRINT ""!""";
            var commodore64 = new Commodore64(input);
            //act
            var result = commodore64.Interpret();
            //assert
            result.Should().Be("Hi\nThere\n!");
        }
    }
}
