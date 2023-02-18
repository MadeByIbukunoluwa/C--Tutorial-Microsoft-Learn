// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Xml.Linq;
using static program.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace program
{
    public class Vegetable
    {
        public Vegetable(string name) => Name = name;
        public string Name { get; }
        public override string ToString() => Name;
    }
    public class Program
    {
        public enum Unit { item,kilogram,gram,dozen}
        public static void Main()
        {
            var item = new Vegetable("eggplant");
            var date = DateTime.Now;
            var price = 1.99m;
            var unit = Unit.item;
            Console.WriteLine("Hello, World!");

            var name = "<name>";
            Console.WriteLine($"Hello,{name}.Its a pleasure to meet you");
            Console.WriteLine($"On {date:d},the price of {item} was {price:C2} per {unit}");
            var titles = new Dictionary<string, string>()
            {
                ["Doyle,Arthur Conan"] = "Hound of the Baskervilles, The",
                ["London, Jack"] = "Call of the Wild, The",
                ["Shakespeare,William"] = "Tempest, The"
            };
            Console.WriteLine("Author and Title List");
            Console.WriteLine();
            Console.WriteLine($"|{"Author",-25}|{"Title",30}|");
            foreach(var title in titles)
                Console.WriteLine($"|{title.Key,-25}|{title.Value,30}|");
        }
        
    }
   
}