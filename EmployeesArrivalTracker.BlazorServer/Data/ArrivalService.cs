using EmployeesArrivalTracker.BlazorServer.Data;

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
        
    }
}
