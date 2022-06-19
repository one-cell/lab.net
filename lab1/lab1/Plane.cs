using System;

namespace lab1
{
    public class Plane
    {
        public string Label { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public DateTime YearOfIssue { get; set; }

        public string VinCode { get; set; }

        public override string ToString() => string.Format("Plane Label is {0} and model is {1}. {2} and year of issue is {3}. Body type, vincode is {4}, {5}", (object) this.Label, (object) this.Model, (object) this.Manufacturer, (object) this.YearOfIssue.Year, (object) this.Type, (object) this.VinCode);
    }
}