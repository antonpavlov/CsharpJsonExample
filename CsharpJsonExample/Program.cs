using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CsharpJsonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var videogames = new List<string>{"Starcraft", "Halo", "Legend of Zelda"};

            // Serialization in the code
            string json_string = JsonConvert.SerializeObject(videogames);
            Console.Write("Serialized string: ");
            Console.WriteLine(json_string);
            // ["Starcraft","Halo","Legend of Zelda"]

            // Write JSON to file
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"D:\Tests\json.txt"))  // <- Important to choose a writable location
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                // Serialize original string and write to file
                serializer.Serialize(writer, videogames);
                // ["Starcraft","Halo","Legend of Zelda"]
            }

            // Read JSON from file
            using (StreamReader sr = new StreamReader(@"D:\Tests\json.txt"))
            {
                string json_file = sr.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<string>>(json_file);
                Console.Write("Read from file: ");
                Console.WriteLine(json_file);
                // ["Starcraft","Halo","Legend of Zelda"]
            }

            // Keep program window open after completion
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
