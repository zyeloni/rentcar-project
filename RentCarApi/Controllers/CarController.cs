using Microsoft.AspNetCore.Mvc;
using RentCarApi.Models;

namespace RentCarApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : Controller
{
    [HttpGet("Get")]
    public IEnumerable<Car> Get()
    {
        return Data.Cars;
    }

    [HttpGet("Delete")]
    public IEnumerable<Car> Delete(int Id)
    {
        List<Car> removed = Data.Cars.Where(x => x.Id == Id).ToList();
        Data.Cars.RemoveAll((x) => x.Id == Id);

        return removed;
    }
}