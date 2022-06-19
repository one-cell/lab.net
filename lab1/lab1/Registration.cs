using System.Collections.Generic;
using System.Drawing;

namespace lab1
{
    public class Registration
    {
        public Plane Plane { get; set; }

        public PlaneCondition PlaneCondition { get; set; }

        public Color Color { get; set; }

        public Pilot ActualPilot { get; set; }

        public List<Pilot> AllPilots { get; set; }

        public override string ToString() => string.Format("{0}. Plane condition is {1} and color is {2}. Actual Pilot is {3} and All the other Pilots are {4}", (object) this.Plane, (object) this.PlaneCondition, (object) this.Color, (object) this.ActualPilot, (object) string.Join<Pilot>(", ", (IEnumerable<Pilot>) this.AllPilots));
    }
}