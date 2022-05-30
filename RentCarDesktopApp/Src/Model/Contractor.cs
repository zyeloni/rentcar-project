using System;

namespace RentCarDesktopApp.Model;

public class Contractor : IModel
{
    public int Id { get; set; }
    public String FirstName { get; set; }
    public String SurName { get; set; }
}