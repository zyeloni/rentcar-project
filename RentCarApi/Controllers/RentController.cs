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
    public IEnumerable<Car> Delete(int Id)
    {
        List<Car> removed = Data.Cars.Where(x => x.Id == Id).ToList();
        Data.Cars.RemoveAll((x) => x.Id == Id);

        return removed;
    }


    [HttpPost("Add")]
    public Car Add(Car model)
    {
        int maxId = Data.Cars.Max(x => x.Id);
        model.Id = maxId + 1;
        Data.Cars.Add(model);
        return model;
    }

    [HttpPost("Edit")]
    public Car Edit(Car model)
    {
        var index = Data.Cars.FindIndex(c => c.Id == model.Id);
        Data.Cars[index] = model;

        return model;
    }
}