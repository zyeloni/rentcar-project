using Microsoft.AspNetCore.Mvc;
using RentCarApi.Models;

namespace RentCarApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RentController : Controller
{
    [HttpGet("Get")]
    public IEnumerable<Rent> Get()
    {
        return Data.Rents;
    }

    [HttpGet("Delete")]
    public IEnumerable<Rent> Delete(int Id)
    {
        List<Rent> removed = Data.Rents.Where(x => x.Id == Id).ToList();
        Data.Rents.RemoveAll((x) => x.Id == Id);

        return removed;
    }


    [HttpPost("Add")]
    public Rent Add(Rent model)
    {
        int maxId = Data.Rents.Max(x => x.Id);
        model.Id = maxId + 1;
        Data.Rents.Add(model);
        return model;
    }

    [HttpPost("Edit")]
    public Rent Edit(Rent model)
    {
        var index = Data.Rents.FindIndex(c => c.Id == model.Id);
        Data.Rents[index] = model;

        return model;
    }
}