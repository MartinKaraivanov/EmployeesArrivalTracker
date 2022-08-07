using EmployeesArrivalTracker.BlazorServer.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeArrivalTracker.BlazorServer.Controllers
{
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


    }
}
