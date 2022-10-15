// See https://aka.ms/new-console-template for more information


using Bogus;

var address = new Faker<Address>("tr")
    .RuleFor(x => x.City, x => x.Address.City())
    .RuleFor(x => x.StreetName, x => x.Address.StreetName())
    .RuleFor(x => x.ZipCode, x => x.Address.ZipCode());

var user = new Faker<User>("tr")
    .RuleFor(y=>y.Id, y=>y.Random.Guid())
    .RuleFor(y=>y.Gender, y=>y.PickRandom<Gender>())
    .RuleFor(y => y.Address, address)
    .RuleFor(y => y.BirthDate, y => y.Date.PastOffset(60, DateTime.Now.AddYears(-18)).Date)
    .RuleFor(y => y.FirstName, y => y.Person.FirstName)
    .RuleFor(y=>y.LastName, y=>y.Person.LastName)
    .RuleFor(y=>y.UserName, (y,z)=>y.Internet.UserName(z.FirstName,z.LastName))
    .RuleFor(y=>y.EmailAddress, y=>y.Person.Email);    //z burada user'ı temsil ediyor, user'ın FirstName'ine bu şekilde ulaşırız 


var genereateObject = user.Generate(5);

Console.WriteLine("Hello, World!");


public class Address
{
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string StreetName { get; set; }
}

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }
    public DateTime BirthDate { get; set; }

}

public enum Gender
{
    Male,
    Female
}