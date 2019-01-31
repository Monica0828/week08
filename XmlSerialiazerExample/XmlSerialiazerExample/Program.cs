using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialiazerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dog dog = new Dog()
            {
                Name = "Oxy",
                Breed = "Chihuahua"

            };
            using (var writer = new System.IO.StreamWriter(@"C:\Users\mdanca\Documents\test2.txt"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Dog));
                serializer.Serialize(writer, dog);
                writer.Flush();
            }

            Dog output = null;
            using (var stream = System.IO.File.OpenRead(@"C:\Users\mdanca\Documents\test2.txt"))
            {
                var serializer = new XmlSerializer(typeof(Dog));
                output= serializer.Deserialize(stream) as Dog;
            }
            Console.WriteLine(output.Name);
            Console.ReadKey();
            }
        }
    }
