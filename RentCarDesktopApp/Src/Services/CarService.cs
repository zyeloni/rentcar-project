using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;

namespace RentCarDesktopApp.Services;

public class CarService
{
    private ApiAccessLayer<Car> _apiAccessLayer;

    public CarService()
    {
        _apiAccessLayer = new ApiAccessLayer<Car>("Car");
    }

    public async Task<IEnumerable<Car>> GetAll()
    {
        return await _apiAccessLayer.GetAll().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Car>> Delete(Car car)
    {
        return await _apiAccessLayer.Delete(car);
    }

    public async Task<Car> Add(Car car)
    {
        return await _apiAccessLayer.Add(car);
    }

    public async Task<Car> Edit(Car car)
    {
        return await _apiAccessLayer.Edit(car);
    }
}