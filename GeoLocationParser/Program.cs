

namespace GeoLocationParser;

class Program
{
    private static readonly ILog logger = new TacoLogger();
    const string CsvPath = "TacoBell-US-AL.csv";
    static void Main(string[] args)
    {
        logger.LogInfo("Log Initialized");



        var lines = File.ReadAllLines(CsvPath);

        if (lines.Length == 0)
        {
            logger.LogError("File has no input");
        }

        if (lines.Length == 1)
        {
            logger.LogWarning("File only has one line of input.");
        }
        
        logger.LogInfo($"Lines: {lines[0]}");

        var parser = new TacoParser();
        var locations = lines.Select(parser.Parse).ToArray();

        ITrackable tacobell1 = null;
        ITrackable tacobell2 = null;
        
        











    }
}