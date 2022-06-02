using RentCarDesktopApp.Model;
using System.Collections.Generic;

namespace RentCarDesktopApp.Src.ViewModel;

public class ReservationsViewModel : IViewModel<Car>
{
    public ReservationsViewModel()
    {
        
    }

    public IEnumerable<Car> Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Search(string key)
    {
        throw new System.NotImplementedException();
    }
}