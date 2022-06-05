using RentCarDesktopApp.Model;

namespace RentCarApi.Models;

public class Rent
{
    public int Id { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public Contractor Contractor { get; set; }
    public Car Car { get; set; }
}