﻿using System;
using RentCarDesktopApp.Core;

namespace RentCarDesktopApp.Model;

public class Car : ObservableObject, IModel
{
    public int Id { get; set; }
    public String Brand { get; set; }
    public String Model { get; set; }
    public DateTime Year { get; set; }
    
}