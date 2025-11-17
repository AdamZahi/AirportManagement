// See https://aka.ms/new-console-template for more information
using AM.APP.CORE.domain;

Console.WriteLine("Hello, World!");

Plane BoingPlane = new Plane { PlaneType = PlaneType.Boeing, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };
Plane AirbusPlane = new Plane { PlaneType = PlaneType.Airbus, Capacity = 250, ManufactureDate = new DateTime(2020, 11, 11) };

Console.WriteLine(BoingPlane.ToString());

Passanger passanger1 = new Passanger
{
    FirstName = "Jane",
    LastName = "Doe"
};
Passanger passanger2 = new Passanger
{
    FirstName = "John",
    LastName = "Doe",
    EmailAddress = "john.doe@test.tn"
};
Staff staffMember = new Staff {FirstName="Adam", LastName="Zahi", function="Pilot", salary=15000, BirthDate=DateTime.Today};
//Console.WriteLine(passanger1.checkProfile("Jane", "Doe"));
//Console.WriteLine(passanger2.checkProfile("John", "Doe", "john.doe@test.tn"));
Console.WriteLine(passanger1.logIn("Jane", "Doe"));
Console.WriteLine(passanger2.logIn("John", "Doe", "john.doe@test.tn"));
passanger1.passangerType();
Console.WriteLine("------------------------------------------");
staffMember.passangerType();