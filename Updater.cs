using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using WebApiClientConsoleApp.Models;

namespace WebApiClientConsoleApp
{
    public class Updater
    {
        public static void UpdateDb(List<DrawResultDto> dto, List<DrawResultJsonDbContext> jsonDbContext) 
        {
            if (dto[0].DrawSystemId == jsonDbContext[0].DrawSystemId)
            {
                Console.WriteLine("Database is up to date");
            }
            else 
            {
                Console.WriteLine($"First json element: {jsonDbContext[0].DrawSystemId}");

                var diff = dto[0].DrawSystemId - jsonDbContext[0].DrawSystemId;
                
                for (int i = 0; i < diff; i++)
                {

                    jsonDbContext.Insert(i, new DrawResultJsonDbContext()
                    {
                        DrawDate = dto[i].DrawDate,
                        DrawSystemId = dto[i].DrawSystemId,
                        GameType = dto[i].GameType,
                        ResultsJson = dto[i].ResultsJson,
                        SpecialResults = dto[i].SpecialResults
                    });
                }

                jsonDbContext.ForEach(x => {
                    x.ResultsJson.Sort();
                    x.SpecialResults.Sort();
                });

                Serializer<DrawResultJsonDbContext>.SerializeAndWrite(jsonDbContext);
                
                Console.WriteLine($"has been updated to: {jsonDbContext[0].DrawSystemId}");
            }
            
        }
    }
}