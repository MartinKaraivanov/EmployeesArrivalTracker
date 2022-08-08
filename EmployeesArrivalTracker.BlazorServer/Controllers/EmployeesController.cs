using EmployeesArrivalTracker.BlazorServer.Data;
using EmployeesArrivalTracker.BlazorServer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeArrivalTracker.BlazorServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly EmployeesArrivalDbContext _dbContext;

    public EmployeesController(EmployeesArrivalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("GetArrivals")]
    public IEnumerable<Arrival> GetArrivals()
    {
        return _dbContext.Arrivals.ToList();
    }

    [HttpPost("AddEmployees")]
    public void AddEmployees([FromBody] IEnumerable<EmployeeParam>? newEmployees)
    {
        Console.WriteLine("Stignahme tuka 2");

        _dbContext.Employees.AddRange(newEmployees.Select(item => new Employee() { EmployeeId = item.Id, FirstName = item.Name, LastName = item.SurName, Age = item.Age }));

        _dbContext.SaveChanges();
    }

    [HttpPost("AddArrivals")]
    public void AddArrivals([FromBody] IEnumerable<ArrivalParam>? newArrivals)
    {
        Console.WriteLine("Stignahme tuka");   

        _dbContext.Arrivals.AddRange(newArrivals.Select(item => new Arrival() { EmployeeId = item.EmployeeId, ArrivalDatetime = item.When }));

        _dbContext.SaveChanges();
    }

    public class ArrivalParam
    {
        public int EmployeeId { get; set; }
        public DateTime When { get; set; }
    }

    public class EmployeeParam
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public int Age { get; set; }
    }
}
