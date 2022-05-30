using Microsoft.AspNetCore.Mvc;
using RentCarApi.Models;
using RentCarDesktopApp.Model;

namespace RentCarApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractorController : Controller
{
    [HttpGet("Get")]
    public IEnumerable<Contractor> Get()
    {
        return Data.Contractors;
    }

    [HttpGet("Delete")]
    public IEnumerable<Contractor> Delete(int Id)
    {
        List<Contractor> removed = Data.Contractors.Where(x => x.Id == Id).ToList();
        Data.Contractors.RemoveAll((x) => x.Id == Id);

        return removed;
    }


    [HttpPost("Add")]
    public Contractor Add(Contractor model)
    {
        int maxId = Data.Contractors.Max(x => x.Id);
        model.Id = maxId + 1;
        Data.Contractors.Add(model);
        return model;
    }

    [HttpPost("Edit")]
    public Contractor Edit(Contractor model)
    {
        var index = Data.Contractors.FindIndex(c => c.Id == model.Id);
        Data.Contractors[index] = model;

        return model;
    }
}