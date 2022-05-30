using RentCarApi.Models;
using RentCarDesktopApp.Model;

namespace RentCarApi;

public class Data
{
    public static List<Car> Cars = Enumerable.Range(1, 20).Select(index => new Car
    {
        Id = index,
        Brand = "Abc" + index,
        Model = "model " + index,
        Year = DateTime.Now.AddDays(index),
    }).ToList();
    
    public static List<Contractor> Contractors = Enumerable.Range(1, 20).Select(index => new Contractor()
    {
        Id = index,
        FirstName = "Imie " + index,
        SurName = "Naziwsko  " + index,
    }).ToList();
}