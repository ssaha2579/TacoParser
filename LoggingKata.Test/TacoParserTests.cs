using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange: Set up everything needed to test the method
            var tacoParser = new TacoParser();

            //Act : Call the Method you want to test
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert : Check that the result is what is expeccted 
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange:Set up everything needed to test the method 
            var tacoParserInstance = new TacoParser();

            //Act: Call the Method you want to test
            var actual = tacoParserInstance.Parse(line);

            //Assert: Check that the result is what is expeccted 
            Assert.Equal(expected, actual.Location.Longitude);
        }
        
    }
}
