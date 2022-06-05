using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;

namespace RentCarDesktopApp.Services;

public class RentService
{
    private ApiAccessLayer<Rent> _apiAccessLayer;

    public RentService()
    {
        _apiAccessLayer = new ApiAccessLayer<Rent>("Rent");
    }

    public async Task<IEnumerable<Rent>> GetAll()
    {
        return await _apiAccessLayer.GetAll().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Rent>> Delete(Rent rent)
    {
        return await _apiAccessLayer.Delete(rent);
    }

    public async Task<Rent> Add(Rent rent)
    {
        return await _apiAccessLayer.Add(rent);
    }

    public async Task<Rent> Edit(Rent rent)
    {
        return await _apiAccessLayer.Edit(rent);
    }
}