using System;

namespace RentCarDesktopApp.Model;

public class Rent : IModel
{
    public int Id { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public Contractor Contractor { get; set; }
    public Car Car { get; set; }

    public int Days
    {
        get
        {
            return (int) (DateEnd - DateStart).TotalDays;
        }
    }
}