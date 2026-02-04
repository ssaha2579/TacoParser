
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        //This test verifies the parser 
        //creates an object from a valid CSV line
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange: Create the parser
            var tacoParser = new TacoParser();

            //Act: Parse one valid CSV row
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert: parsing valid input should not return null 
            Assert.NotNull(actual);
        }
        
        // This theory verifies that the parser correctly extracts
        // the longitude (second value) from multiple CSV rows.
        [Theory] 
        // Format: "latitude, longitude, name", expectedLongitude
        [InlineData("34.9441838, -84.677017, Taco Bell Acwort...", -84.677017)] 
        [InlineData("31.597099, -84.176122, Taco Bell Albany...", -84.176122)]
        [InlineData("33.22997,-86.805275, Taco Bell Alabaste...", -86.805275)]
        [InlineData("34.7348,-86.633875,Taco Bell Huntsville...", -86.633875)]
        [InlineData("33.929611,-86.023705, Taco Bell Southside...", -86.023705)]
        
        
        
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange: Create the parser 
            var tacoParserInstance = new TacoParser();

            //Act: Parse the CSV 
            var actual = tacoParserInstance.Parse(line);

            //Assert: longitude should match the value in the CSV
            Assert.Equal(expected, actual.Location.Longitude);
        }
        
        // This theory verifies that the parser correctly extracts
        // the latitude (first value) from multiple CSV rows.
        [Theory]
        // Format: "latitude, longitude, name", expectedLatitude
        [InlineData("34.9441838, -84.677017, Taco Bell Acwort...", 34.9441838)]
        [InlineData("31.597099, -84.176122, Taco Bell Albany ... ",31.597099)]
        [InlineData("33.22997,-86.805275, Taco Bell Alabaste...", 33.22997)]
        [InlineData("34.7348,-86.633875,Taco Bell Huntsville...",34.7348)]
        [InlineData("33.929611,-86.023705, Taco Bell Southside...", 33.929611)] 
        
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange: create the parser
            var tacoParserInstance = new TacoParser();
            
            //Act: parse the CSV line
            var actual = tacoParserInstance.Parse(line);
            
            //Assert: latitude should match the value in the CSV
            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
