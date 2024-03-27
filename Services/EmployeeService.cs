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

            return await _dbContext.Employees.Include(e => e.Manager).Include(e => e.Department).ToListAsync();

        }
    }
}
