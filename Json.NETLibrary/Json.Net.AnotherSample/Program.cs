using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json.Net.AnotherSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person { Id = 1, Name = "Sabrina Ceballos", DateOfBirth = new DateTime(1990, 05, 12) };
            //string miJson = JsonSerializer.Serialize(person);
            //Console.WriteLine(miJson);
            //File.WriteAllText("esUnJson.txt", miJson);

            string jsonInFile = File.ReadAllText("esUnJson.txt");
            Person persona = JsonSerializer.Deserialize<Person>(jsonInFile);
            Console.WriteLine(persona.Name);
            
        }
    }
}
