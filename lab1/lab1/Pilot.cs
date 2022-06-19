using System;

namespace lab1
{
    public class Pilot
        {
            public string PilotLicense { get; set; }

            public string Name { get; set; }

            public string Surname { get; set; }

            public string Patronymic { get; set; }

            public DateTime DateOfBirth { get; set; }

            public string AddressRegistration { get; set; }

            public override string ToString() => string.Format("Pilot is {0} {1} {2} and date of birth: {3}.{4}.{5}. Driver Pilot is {6}, address registration is {7}", (object) this.Surname, (object) this.Name, (object) this.Patronymic, (object) this.DateOfBirth.Day, (object) this.DateOfBirth.Month, (object) this.DateOfBirth.Year, (object) this.PilotLicense, (object) this.AddressRegistration);
        }
}