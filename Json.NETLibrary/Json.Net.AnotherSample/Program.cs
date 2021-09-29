using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json.Net.AnotherSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Id = 1, Name = "Sabrina Ceballos", DateOfBirth = new DateTime(1990, 05, 12) };
            string miJson = JsonSerializer.Serialize(person);
            Console.WriteLine(miJson);

            
        }
    }
}
