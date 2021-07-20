using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiClientConsoleApp.Models
{
    public class Results
    {
        [JsonPropertyName("drawDate")]
        public DateTime DrawDate { get; set; }
        [JsonPropertyName("drawSystemId")]
        public int DrawSystemId { get; set; }
        
        [JsonPropertyName("gameType")]
        public string GameType { get; set; }
        
        [JsonPropertyName("resultsJson")]
        public List<int> ResultsJson { get; set; }
        
        [JsonPropertyName("specialResults")]
        public List<int> SpecialResults { get; set; }
    }
}


// drawDate
// drawSystemId 
// gameType
// resultsJson
// specialResults