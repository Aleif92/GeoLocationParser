using GeoLocationParser;

namespace GeoLocationParserTest;

public class UnitTest1
{
    [Fact]
    public void ShouldReturnNonNullObject()
    {
        var tacoParser = new TacoParser();
    }

    [Theory]
    [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
    [InlineData("34.376395,-84.913185,Taco Bell Adairsvill...", -84.913185)]
    //Add additional inline data. Refer to your CSV file.
    public void ShouldParseLongitude(string line, double expected)
    {
        // TODO: Complete the test with Arrange, Act, Assert steps below.
        //       Note: "line" string represents input data we will Parse 
        //       to extract the Longitude.  
        //       Each "line" from your .csv file
        //       represents a TacoBell location

        //Arrange
        var tacoParser = new TacoParser();

        //Act
        var actual = tacoParser.Parse(line);

        //Assert
        Assert.Equal(expected, actual.Location.Longitude);
    }
}