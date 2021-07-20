using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApiClientConsoleApp.Models;

namespace WebApiClientConsoleApp
{
    public class Serializer<T>
    {
        public static void SerializeAndWrite(List<T> dto)
        {
            // Serialize and write to json file
            var serialize = JsonSerializer.Serialize<List<T>>(dto);
            
            var fullPath = string.Join(Environment.CurrentDirectory, "DrawResults.json");

            File.WriteAllText(fullPath, serialize);
        }
        
        public static List<T> DeserializeJsonDbContext()
        {
            var fullPath = string.Join(Environment.CurrentDirectory, "DrawResults.json");

            var stringDbContext = File.ReadAllText(fullPath);
            
            return JsonSerializer.Deserialize<List<T>>(stringDbContext);
        }
    }
}