using library;
using System.Xml.Serialization;

namespace Lab_08_01{
    class Program{

        static void Main(){

            XmlSerializer mySerializer = new XmlSerializer(typeof(Animal));

            Animal testAnimal = new Animal("Bolivia",true,"Billy Bob Jones","Worm");

            using (FileStream output = File.Create("test.xml")){
                mySerializer.Serialize(output, testAnimal);
                Console.WriteLine("Serializing...............");
            }

            Animal cloneAnimal;

            using (FileStream input = File.Open("test.xml", FileMode.Open)){
                cloneAnimal = (Animal)mySerializer.Deserialize(input);
                Console.WriteLine("Deserializing...............");
            }

            Console.WriteLine($"Country: {cloneAnimal.Country}" +
                            $"\n{(cloneAnimal.HideFromOtherAnimals? "Hides" : "Doesn't hide")} from other animals" +
                            $"\nName: {cloneAnimal.Name}"+
                            $"\nIs a {cloneAnimal.WhatAnimal}");
        }
        
    }

}