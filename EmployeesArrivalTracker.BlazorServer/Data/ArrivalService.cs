using EmployeesArrivalTracker.BlazorServer.Data;
using EmployeesArrivalTracker.BlazorServer.Entities;

namespace EmployeesArrivalTracker.BlazorServer.Data
{
    public class ArrivalService
    {
        private readonly EmployeesArrivalDbContext _dbContext;

        public ArrivalService(EmployeesArrivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Arrival[]> GetArrivalsAsync()
        {
            return Task.FromResult(_dbContext.Arrivals.OrderByDescending(x => x.ArrivalDatetime).ToArray());
        }

        public Arrival[] GetById(int employeeId)
        {
            return _dbContext.Arrivals.Where(x => x.EmployeeId == employeeId).ToArray();
        }

        public Arrival[] GetByArrivalDatetime(DateTime arrivalDatetimeFrom, DateTime arrivalDatetimeTo)
        {
            return _dbContext.Arrivals.Where(x => x.ArrivalDatetime >= arrivalDatetimeFrom && x.ArrivalDatetime <= arrivalDatetimeTo).ToArray();
        }
        
    }
}
