using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;

namespace RentCarDesktopApp.Services;

public class ContractorService
{
    private ApiAccessLayer<Contractor> _apiAccessLayer;

    public ContractorService()
    {
        _apiAccessLayer = new ApiAccessLayer<Contractor>("Contractor");
    }

    public async Task<IEnumerable<Contractor>> GetAll()
    {
        return await _apiAccessLayer.GetAll().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Contractor>> Delete(Contractor contractor)
    {
        return await _apiAccessLayer.Delete(contractor);
    }

    public async Task<Contractor> Add(Contractor contractor)
    {
        return await _apiAccessLayer.Add(contractor);
    }

    public async Task<Contractor> Edit(Contractor contractor)
    {
        return await _apiAccessLayer.Edit(contractor);
    }
}