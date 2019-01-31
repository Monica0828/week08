using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JsonSerialiazer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog()
            {
                Name = "Oxy",
                Breed = "Chihuahua"
            };
            JObject json = (JObject)JToken.FromObject(dog);

            File.WriteAllText(@"C:\Users\mdanca\Documents\test.txt", json.ToString());

            using (StreamWriter file = File.CreateText(@"C:\Users\mdanca\Documents\test.txt"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                json.WriteTo(writer);
            }

            JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\mdanca\Documents\test.txt"));
            var o2 = new JObject();
            using (StreamReader file = File.OpenText(@"C:\Users\mdanca\Documents\test.txt"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    o2 = (JObject)JToken.ReadFrom(reader);
                }

                Console.WriteLine(o2);
                Console.ReadKey();
            }
        }
    }
}
