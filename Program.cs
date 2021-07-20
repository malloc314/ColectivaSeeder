using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApiClientConsoleApp.Models;

namespace WebApiClientConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Create the json file
                // Create the {DrawResults.json} file if not exists
                var fullPath = string.Join(Environment.CurrentDirectory, "DrawResults.json");
                
                if (!File.Exists(fullPath))
                    await Creator.CreateJsonFile();
                else 
                    Console.WriteLine("Json db file exists");
            #endregion
            
            #region Update the json file
                // Deserialize {DrawResults.json} to the {DrawResultJsonDbContext} object to check for updates
                var jsonDbContext = Serializer<DrawResultJsonDbContext>.DeserializeJsonDbContext();
                
                // Get {n} the latest drawing results from API
                var drawResults = await WebClient.ProcessDrawResults(10);
                
                // Mapping the {DrawResult} object to the simplified {DrawResultDto} object
                var drawResultsDto = Mapper.MapToDto(drawResults);

                // Checks and updates the database
                Updater.UpdateDb(drawResultsDto, jsonDbContext);
            #endregion

            #region The Colectiva math engine
            // Mapping context to columns
                var columns = jsonDbContext.Select(x => new Columns()
                {
                    First = x.ResultsJson[0],
                    Second = x.ResultsJson[1],
                    Thrid = x.ResultsJson[2],
                    Fourth = x.ResultsJson[3],
                    Fifth = x.ResultsJson[4],
                    Sixth = x.SpecialResults[0],
                    Seventh = x.SpecialResults[1]
                }).ToList();
                
                // Add to columns
                List<int> first = new List<int>();
                List<int> second = new List<int>();
                List<int> thrid = new List<int>();
                List<int> fourth = new List<int>();
                List<int> fifth = new List<int>();
                List<int> sixth = new List<int>();
                List<int> seventh = new List<int>();

                columns.ForEach(x => 
                {
                    first.Add(x.First);
                    second.Add(x.Second);
                    thrid.Add(x.Thrid);
                    fourth.Add(x.Fourth);
                    fifth.Add(x.Fifth);
                    sixth.Add(x.Sixth);
                    seventh.Add(x.Seventh);
                });

                // Randomize column index
                Random rnd = new Random();
                List<int> draw = new List<int>();

                draw.Add(first[rnd.Next(1, (50 + 1))]);
                draw.Add(second[rnd.Next(1, (50 + 1))]);
                draw.Add(thrid[rnd.Next(1, (50 + 1))]);
                draw.Add(fourth[rnd.Next(1, (50 + 1))]);
                draw.Add(fifth[rnd.Next(1, (50 + 1))]);
                draw.Add(sixth[rnd.Next(1, (50 + 1))]);
                draw.Add(seventh[rnd.Next(1, (50 + 1))]);

                // Print the sequence
                draw.ForEach(x => Console.WriteLine(x));
                Console.WriteLine($"{first.Min()}, {first.Max()}");
            #endregion
        }
    }
}
