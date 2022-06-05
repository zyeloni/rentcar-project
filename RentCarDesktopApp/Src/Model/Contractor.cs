using System;
using Microsoft.VisualBasic;

namespace RentCarDesktopApp.Model;

public class Contractor : IModel
{
    public int Id { get; set; }
    public String FirstName { get; set; }
    public String SurName { get; set; }

    public String FullName
    {
        get { return String.Format("{0} {1}", FirstName, SurName); }
    }
}