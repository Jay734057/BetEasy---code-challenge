using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using System;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Fclp.FluentCommandLineParser<Args>();
            parser.Setup(x => x.CaulfieldRace).As('c', "Caulfield").SetDefault(false);
            parser.Setup(x => x.WolferhamptonRace).As('w', "Wolferhampton").SetDefault(false);

            var result = parser.Parse(args);

            if (result.EmptyArgs)
            {
                Console.WriteLine($"Usage: -[c]Caulfield true|false -w Wolferhampton true|false ");
                Environment.Exit(1);
            }

            if (parser.Object.CaulfieldRace)
            {
                Console.WriteLine("======================================================");
                Console.WriteLine("Caulfield Race Price");
                Console.WriteLine("======================================================");

                var doc = XmlParser<Meeting>.Parse($"{Constants.FILE_PATH}/{Constants.XML_FILE_NAME}");
                foreach (var race in doc.Races)
                {
                    Console.WriteLine($"Race {race.Id}:");

                    foreach (var price in race.Prices)
                    {
                        Console.WriteLine($"Type: {price.Type}");

                        var horsesInPriceAscendingOrder = price.Horses.OrderBy(x => double.Parse(x.Price));

                        foreach (var horseWithPrice in horsesInPriceAscendingOrder)
                        {
                            var horse = race.Horses.Single(x => x.Number == horseWithPrice._Number);
                            Console.WriteLine($"Horse {horse.Id} - {horse.Name} - Price: {horseWithPrice.Price}");
                        }
                    }
                }
                Console.WriteLine();
            }


            if (parser.Object.WolferhamptonRace)
            {
                Console.WriteLine("======================================================");
                Console.WriteLine("Wolferhampton Race Price");
                Console.WriteLine("======================================================");

                var doc = JsonParser<WolferhamptonRace>.Parse($"{Constants.FILE_PATH}/{Constants.JSON_FILE_NAME}");

                foreach (var market in doc.RawData.Markets)
                {
                    Console.WriteLine($"Market {market.Id}:");
                    var selectionsInPriceAscendingOrder = market.Selections.OrderBy(x => x.Price);
                    var participants = doc.RawData.Participants;

                    foreach (var selectionPrice in selectionsInPriceAscendingOrder)
                    {
                        var participant = participants.Single(x => x.Id == Int32.Parse(selectionPrice.Tags.participant));
                        Console.WriteLine($"Participant {participant.Id} - {participant.Name} - Price: {selectionPrice.Price}");
                    }
                }
                Console.WriteLine();

            }

            Console.WriteLine("Press any key to exit . . .");
            Console.ReadKey();
        }
    }
}