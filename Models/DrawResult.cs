using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WebApiClientConsoleApp.Models
{
    public class DrawResult
    {   
        [JsonPropertyName("items")]
        public List<Items> Items { get; set; }     
    }
}