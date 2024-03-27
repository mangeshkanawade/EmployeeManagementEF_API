using EmployeeManagementEF.Data.Models;
using EmployeeManagementEF.Models;

namespace EmployeeManagementEF.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> GetEmployeeByEmailAsync(string email);
        Task<bool> AddEmployee(EmployeeModel employee);
    }
}
