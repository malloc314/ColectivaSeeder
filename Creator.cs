using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiClientConsoleApp.Models;

namespace WebApiClientConsoleApp
{
    public class Creator
    {
        public static int Size { get; set; } = 1;
        public async static Task CreateJsonFile() 
        {
            // Get {n} draw results from API
            var drawResults = await WebClient.ProcessDrawResults(Size);
            
            // Mapping the {DrawResult} object to the simplified {DrawResultDto} object
            var drawResultsDto = Mapper.MapToDto(drawResults);

            // Set a new value
            Size = drawResultsDto[0].DrawSystemId;

            // Get {n} draw results from API
            drawResults = await WebClient.ProcessDrawResults(Size);

            // Mapping the {DrawResult} object to the simplified {DrawResultDto} object
            drawResultsDto = Mapper.MapToDto(drawResults);
            
            drawResultsDto.ForEach(x => {
                x.ResultsJson.Sort();
                x.SpecialResults.Sort();
            });
            
            // Create the {DrawResults.json} file
            Serializer<DrawResultDto>.SerializeAndWrite(drawResultsDto);
        }
    }
}