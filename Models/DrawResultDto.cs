using System;
using System.Collections.Generic;

namespace WebApiClientConsoleApp.Models
{
    public class DrawResultDto
    {
        public DateTime DrawDate { get; set; }
        public int DrawSystemId { get; set; }
        public string GameType { get; set; }
        public List<int> ResultsJson { get; set; }
        public List<int> SpecialResults { get; set; }
    }
}