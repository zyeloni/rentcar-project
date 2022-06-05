using RentCarApi.Models;
using RentCarDesktopApp.Model;

namespace RentCarApi;

public class Data
{
    private static List<String> Brands = new List<string>()
    {
        "Opel",
        "Volkswagen",
        "Porshe",
        "Toyota",
        "Mercedes",
    };


    public static List<Car> Cars = Enumerable.Range(1, 20).Select(index => new Car
    {
        Id = index,
        Brand = Brands.OrderBy(x => Guid.NewGuid()).FirstOrDefault(),
        Model = "model " + index,
        Year = DateTime.Now.AddDays(index),
    }).ToList();
    
    public static List<Contractor> Contractors = Enumerable.Range(1, 20).Select(index => new Contractor()
    {
        Id = index,
        FirstName = Faker.Name.First(),
        SurName = Faker.Name.Last(),
    }).ToList();
    
    public static List<Rent> Rents = Enumerable.Range(1, 20).Select(index => new Rent()
    {
        Id = index,
        Contractor = Contractors[index-1],
        Car = Cars[index-1],
        DateStart = DateTime.Now,
        DateEnd = DateTime.Now.Add(new TimeSpan(index,0,0,0))
    }).ToList();
}