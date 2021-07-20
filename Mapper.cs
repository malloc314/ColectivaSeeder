using System;
using System.Collections.Generic;
using System.Linq;
using WebApiClientConsoleApp.Models;

namespace WebApiClientConsoleApp
{
    public class Mapper
    {
        public static List<DrawResultDto> MapToDto(DrawResult drawResults) 
        {
            // Mapping to DTO
            return drawResults.Items
                .Select(x => new DrawResultDto()
                {   
                    DrawDate = x.Results[0].DrawDate,
                    DrawSystemId = x.Results[0].DrawSystemId,
                    GameType = x.Results[0].GameType,
                    ResultsJson = x.Results[0].ResultsJson,
                    SpecialResults = x.Results[0].SpecialResults
                })
                .ToList();
        }
    }
}