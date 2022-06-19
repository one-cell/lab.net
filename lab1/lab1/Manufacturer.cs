using System;

namespace lab1
{
    public class Manufacturer
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Founded { get; set; }

        public int NumberOfEmployees { get; set; }

        public override string ToString() => string.Format("Manufacturer is {0}, location: {1}, founded date: {2}.{3}.{4}, number of employees is {5}", (object) this.Name, (object) this.Location, (object) this.Founded.Day, (object) this.Founded.Month, (object) this.Founded.Year, (object) this.NumberOfEmployees);
    }
}