using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace lab1
{
    internal class Program
    {
    private static void Main(string[] args)
    {
      //Pilots
      Pilot pilot1 = new Pilot()
      {
        Name = "Tkach",
        Surname = "Yurii",
        Patronymic = "Olexandrovich",
        DateOfBirth = new DateTime(1900, 12, 3),
        AddressRegistration = "LA",
        PilotLicense = "34gsg342vxd"
      };
      Pilot pilot2 = new Pilot()
      {
        Name = "Stephan",
        Surname = "Kupa",
        Patronymic = "Johnovich",
        DateOfBirth = new DateTime(1983, 1, 1),
        AddressRegistration = "Madrid",
        PilotLicense = "25shh653ktc"
      };
      Pilot pilot3 = new Pilot()
      {
        Name = "Lupa",
        Surname = "Pupovich",
        Patronymic = "Aethetics",
        DateOfBirth = new DateTime(1991, 6, 25),
        AddressRegistration = "Berlin",
        PilotLicense = "85nrj478soi"
      };
      Pilot pilot4 = new Pilot()
      {
        Name = "Liubomir",
        Surname = "Vazhil",
        Patronymic = "Marmeladovich",
        DateOfBirth = new DateTime(1953, 8, 16),
        AddressRegistration = "Chortkiv",
        PilotLicense = "43kgs92xjs"
      };
      Pilot pilot5 = new Pilot()
      {
        Name = "Gaus",
        Surname = "Mann",
        Patronymic = "Molotov",
        DateOfBirth = new DateTime(1995, 3, 3),
        AddressRegistration = "Kopengagen",
        PilotLicense = "25fhs69bfl"
      };
      //Plane Manufacturers
      Manufacturer manufacturer1 = new Manufacturer()
      {
        Name = "Boeing",
        Location = "usa",
        Founded = new DateTime(1916, 7, 12),
        NumberOfEmployees = 12345
      };
      Manufacturer manufacturer2 = new Manufacturer()
      {
        Name = "Antonov",
        Location = "UKraine",
        Founded = new DateTime(1946, 11, 21),
        NumberOfEmployees = 5432
      };
      Manufacturer manufacturer3 = new Manufacturer()
     {
        Name = "Airbus",
        Location = "EU",
        Founded = new DateTime(1969, 4, 1),
        NumberOfEmployees = 7777
      };
            //Planes
      Plane plane1 = new Plane()
      {
        Label = "Sorol",
        Manufacturer = manufacturer1,
        Model = "SLS",
        Type = "Cargo",
        YearOfIssue = new DateTime(2003, 5, 12),
        VinCode = "gushu429834fhs92"
      };
      Plane plane2 = new Plane()
      {
        Label = "Eibus",
        Manufacturer = manufacturer1,
        Model = "A330-200",
        Type = "Passenger",
        YearOfIssue = new DateTime(1999, 3, 8),
        VinCode = "48tfhdg872dgjg"
      };
      Plane plane3 = new Plane()
      {
        Label = "Bella",
        Manufacturer = manufacturer2,
        Model = "ULA",
        Type = "Passenger",
        YearOfIssue = new DateTime(1888, 1, 10),
        VinCode = "vh87dw8y3dfy2yef"
      };
      Plane plane4 = new Plane()
      {
        Label = "Gondola",
        Manufacturer = manufacturer3,
        Model = "CRJ",
        Type = "Passenger",
        YearOfIssue = new DateTime(2015, 8, 13),
        VinCode = "dghsju3y9ysdg8g"
      };
            //Pilot plane licenses
      Registration reg1 = new Registration()
      {
        Plane = plane1,
        PlaneCondition = PlaneCondition.Excellent,
        ActualPilot = pilot1,
        AllPilots = new List<Pilot>() { pilot2, pilot4 }
      };
      Registration reg2 = new Registration()
      {
        Plane = plane1,

        PlaneCondition = PlaneCondition.Good,
        ActualPilot = pilot3,
        AllPilots = new List<Pilot>() { pilot1, pilot4 }
      };
      Registration reg3 = new Registration()
      {
        Plane = plane2,

        PlaneCondition = PlaneCondition.Good,
        ActualPilot = pilot5,
        AllPilots = new List<Pilot>()
        {
          pilot1,
          pilot2,
          pilot3
        }
      };
      Registration reg4 = new Registration()
      {
        Plane = plane3,

        PlaneCondition = PlaneCondition.Bad,
        ActualPilot = pilot5,
        AllPilots = new List<Pilot>()
        {
          pilot3,
          pilot4,
          pilot2
        }
      };
      Registration reg5 = new Registration()
      {
        Plane = plane4,

        PlaneCondition = PlaneCondition.Medium,
        ActualPilot = pilot2,
        AllPilots = new List<Pilot>()
        {
          pilot3,
          pilot1,
          pilot5
        }
      };
      List<Registration> source = new List<Registration>()
      {
        reg1,
        reg2,
        reg3,
        reg4,
        reg5
      };
      Print(reg1.AllPilots.Select((x => x)));
      Print(reg5.AllPilots.Select((x => x.Name)));

      IEnumerable<Pilot> pilots = reg1.AllPilots.Union(reg3.AllPilots);
      Print(pilots);
      Print(pilots.OrderBy((x => x.DateOfBirth)));
      Print(pilots.Union(reg5.AllPilots).Where((x => x.Surname.ToUpper().StartsWith('A'))));
      Console.WriteLine(reg5.AllPilots.Select((x => x.Surname)).Aggregate("", ((longest, next) => next.Length <= longest.Length ? longest : next), (surname => surname.ToUpper())));
      Print(reg1.AllPilots.Except(reg3.AllPilots));

      Print(source.TakeWhile((x => x.PlaneCondition > 0)));
      Console.WriteLine(reg1.AllPilots.ElementAtOrDefault(224));
      Print(reg1.AllPilots.Zip(reg2.AllPilots, (first, second) => string.Format("First: {0}\nSecond: {1}\n\n", first, second)));
      Print(reg2.AllPilots.Intersect(reg3.AllPilots));

      Print(source.Select((x => x.Plane.Manufacturer)).Where((m => m.NumberOfEmployees > 10000)).Distinct());
      Console.WriteLine("Employee average between the companies is {0}", source.Select(x => x.Plane.Manufacturer.NumberOfEmployees).Average());
        Print(source.GroupBy(registration => registration.Plane).Select(g => new
        {
          Plane = g.Key,
          Count = g.Count()
        }));

     
    }
        // method
    private static void Print<T>(IEnumerable<T> list)
    {
      list.ToList<T>().ForEach((Action<T>) (x => Console.WriteLine((object) x)));
      Console.WriteLine("/////");
    }
    }
}