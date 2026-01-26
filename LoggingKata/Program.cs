using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog Logger = new TacoLogger();
        const string CsvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            Logger.LogInfo("Log initialized");
            string[] lines = File.ReadAllLines(CsvPath);
            Logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
            ITrackable[] locations = lines.Select(line => parser.Parse(line)).ToArray();
            ITrackable first = null;
            ITrackable last = null;

            var distance = 0.0d;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];

                    if (i == j) continue;

                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    var currentDistance = corA.GetDistanceTo(corB);

                    if (currentDistance > distance)
                    {
                        distance = currentDistance;
                        first = locA;
                        last = locB;
                    }
                }
            }

            Console.WriteLine("Farthest Taco Bells:");
            Console.WriteLine($"First: {first}");
            Console.WriteLine($"Last: {last}");
            Console.WriteLine($"Distance: {distance:F2}");
        }
    }
}