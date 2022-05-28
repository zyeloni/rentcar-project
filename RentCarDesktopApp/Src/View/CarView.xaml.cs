using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;
using RentCarDesktopApp.Src.ViewModel;

namespace RentCarDesktopApp.Src.View;

public partial class CarView : UserControl
{
    public CarView()
    {
        InitializeComponent();
        DataContext = new CarViewModel();
    }
}