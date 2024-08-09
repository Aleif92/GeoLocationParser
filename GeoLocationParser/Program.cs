
using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

using GeoCoordinatePortable;

namespace GeoLocationParser
{
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

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacobell1 = locA;
                        tacobell2 = locB;

                    }

                }

                








            }
            Console.WriteLine(
                $"{tacobell1.Name} and {tacobell2.Name} are the two Tacobell locations that are farthest apart.\n That is about {Math.Round(distance)} meters apart. That is exactly {Math.Round(distance) * 0.00062137} miles.");





        }
    }
}