using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameFile = "registrations";
            FileOperation.CreateXML(nameFile);
            XElement registrations = XElement.Load(nameFile);
            
            Print(registrations.Descendants("Registration").ElementAt(0).Descendants("Drivers").Select(x => x));
            Print(registrations.Descendants("Registration").ElementAt(4).Descendants("Drivers").Descendants("Name").Select(x => x));
            Print(registrations.Descendants("Registration").Descendants("Vehicle").Descendants("Manufacturer").Where(x=>int.Parse(x.Element("NumberOfEmployee").Value) > 10000));
            Console.WriteLine("Average number of employee is {0}", registrations.Descendants("Registration").Descendants("Vehicle").Descendants("Manufacturer").
                Select(x=>int.Parse(x.Element("NumberOfEmployee").Value)).Average());
            Print(registrations.Descendants("Registration").Descendants("Vehicle").GroupBy(registration => registration.Element("Brand").Value).Select(g => new
            {
                Vehicle = g.Key,
                Count = g.Count()
            }));

            var drivers3 = registrations.Descendants("Registration").ElementAt(2).Descendants("Drivers")
                .Descendants("Driver");
            
            Print(drivers3.Union(registrations.Descendants("Registration").ElementAt(0).Descendants("Drivers").Descendants("Driver")));
            Print(drivers3.OrderByDescending(x=>x.Element("DateOfBirth").Value));
            Print(drivers3.Where((x => x.Element("Surname").Value.ToUpper().StartsWith('A'))));
            Console.WriteLine(registrations.Descendants("Registration").ElementAt(4).Descendants("Drivers").Descendants("Driver").
                Select(x=>x.Element("Surname").Value).
                Aggregate("Longest Surname: ", (longest, next) => next.Length <= longest.Length ? longest : next, surname => surname.ToUpper()));
            Print(registrations.Descendants("Registration").TakeWhile(x => (int)Enum.Parse(typeof(PlaneCondition), x.Element("ConditionCar").Value) > 0));
            Console.WriteLine(registrations.Descendants("Registration").ElementAtOrDefault(224));
            Print(registrations.Descendants("Registration").ElementAt(0).Descendants("Drivers").Zip( registrations.Descendants("Registration").ElementAt(1).Descendants("Drivers"), (first, second) => string.Format("FIRST REGISTRATION: {0}\nSECOND REGISTRATION: {1}\n\n", first, second)));



        }
        
        private static void Print<T>(IEnumerable<T> list)
        {
            list.ToList<T>().ForEach((Action<T>) (x => Console.WriteLine((object) x)));
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
    }
}