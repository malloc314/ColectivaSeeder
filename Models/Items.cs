using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WebApiClientConsoleApp.Models
{
    public class Items
    {        
        [JsonPropertyName("results")]
        public List<Results> Results { get; set; }   
    }
}