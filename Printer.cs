using System;
using WebApiClientConsoleApp.Models;

namespace WebApiClientConsoleApp
{
    public class Printer
    {
        public static void PrintDrawResults(DrawResult drawResults) 
        {
            // Print info
            foreach (var item in drawResults.Items)
            {
                Console.WriteLine($"Draw date: {item.Results[0].DrawDate}");
                Console.WriteLine($"Game type: {item.Results[0].GameType}");
                Console.WriteLine($"Draw ID: {item.Results[0].DrawSystemId}");
                Console.Write("Results: ");
                item.Results[0].ResultsJson.Sort();
                item.Results[0].ResultsJson.ForEach(x => Console.Write($"{x} "));
                item.Results[0].SpecialResults.Sort();
                item.Results[0].SpecialResults.ForEach(x => Console.Write($"{x} "));
                Console.WriteLine("");
                Console.WriteLine("------------------------------");
            }
        }
    }
}