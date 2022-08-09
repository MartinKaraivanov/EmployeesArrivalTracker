using EmployeesArrivalTracker.BlazorServer.Data;
using EmployeesArrivalTracker.BlazorServer.Entities;

namespace EmployeesArrivalTracker.BlazorServer.Data;

public class ArrivalService
{
    private readonly EmployeesArrivalDbContext _dbContext;

    public ArrivalService(EmployeesArrivalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ArrivalViewModel[]> GetArrivalsAsync()
    {
        return Task.FromResult(_dbContext.Arrivals.Select(a => new ArrivalViewModel() { EmployeeId = a.EmployeeId, FirstName = a.Employee.FirstName, LastName = a.Employee.LastName, Age = a.Employee.Age, ArrivalDatetime = a.ArrivalDatetime }).OrderByDescending(a => a.ArrivalDatetime).ToArray());
    }

    public ArrivalViewModel[] GetById(int employeeId)
    {
        return _dbContext.Arrivals.Select(a => new ArrivalViewModel() { EmployeeId = a.EmployeeId, FirstName = a.Employee.FirstName, LastName = a.Employee.LastName, Age = a.Employee.Age, ArrivalDatetime = a.ArrivalDatetime }).Where(a => a.EmployeeId == employeeId).ToArray();
    }

    public ArrivalViewModel[] GetByArrivalDatetime(DateTime arrivalDatetimeFrom, DateTime arrivalDatetimeTo)
    {
        return _dbContext.Arrivals.Select(a => new ArrivalViewModel() { EmployeeId = a.EmployeeId, FirstName = a.Employee.FirstName, LastName = a.Employee.LastName, Age = a.Employee.Age, ArrivalDatetime = a.ArrivalDatetime }).Where(x => x.ArrivalDatetime >= arrivalDatetimeFrom && x.ArrivalDatetime <= arrivalDatetimeTo).ToArray();
    }
    
}
