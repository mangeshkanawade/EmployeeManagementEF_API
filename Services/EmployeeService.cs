using AutoMapper;
using EmployeeManagementEF.Data;
using EmployeeManagementEF.Data.Models;
using EmployeeManagementEF.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementEF.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeService(AppDBContext _appDBContext, IMapper mapper)
        {
            _dbContext = _appDBContext;
            _mapper = mapper;
        }

        async Task<bool> IEmployeeService.AddEmployee(EmployeeModel employee)
        {
            if (_dbContext is null) return false; // Return false if _dbContext is null

            var NewEmp = _mapper.Map<Employee>(employee);

            await _dbContext.AddAsync(NewEmp); // Use await with AddAsync
            await _dbContext.SaveChangesAsync(); // Use await with SaveChangesAsync

            return true; // Return true if operation succeeds
        }

        async Task<Employee> IEmployeeService.GetEmployeeByIdAsync(int id)
        {
            if (_dbContext is null) return null;

            return await _dbContext.Employees.FindAsync(id);
        }

        async Task<Employee> IEmployeeService.GetEmployeeByEmailAsync(string email) {
            if (_dbContext is null) return null;

            var result = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);

            return result;
        }

        async Task<IEnumerable<Employee>> IEmployeeService.GetEmployeesAsync() {
            if (_dbContext is null) return null;

            return await _dbContext.Employees.Include(e => e.Manager).Include(e => e.Status).Include(e => e.Department).ToListAsync();

        }

        async Task<IEnumerable<Employee>> IEmployeeService.GetManagersAsync() {
            if (_dbContext is null) return null;
 
            return await _dbContext.Employees.Include(e => e.Manager).Include(e => e.Department).Include(e=>e.Status).Where(e=> e.ManagerID == null).ToListAsync();
 
        }

        async Task<IEnumerable<EmployeeStatus>> IEmployeeService.GetEmployeeStatusAsync() {
            if (_dbContext is null) return null;

            return await _dbContext.EmployeeStatuses.ToListAsync();
        }

        async Task<EmployeeStatus> IEmployeeService.GetEmployeeStatusByIdAsync(int id) {
            if (_dbContext is null) return null;

            return await _dbContext.EmployeeStatuses.FindAsync(id);
        }

        async Task<bool> IEmployeeService.AddEmployeeStatus(EmployeeManagementEF.Data.Models.EmployeeStatus status) {
            if (_dbContext is null) return false;

            await _dbContext.AddAsync(status);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
