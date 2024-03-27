using EmployeeManagementEF.Data.Models;
using EmployeeManagementEF.Models;

namespace EmployeeManagementEF.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Employee>> GetManagersAsync();
        Task<IEnumerable<EmployeeStatus>> GetEmployeeStatusAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<EmployeeStatus> GetEmployeeStatusByIdAsync(int id);
        Task<Employee> GetEmployeeByEmailAsync(string email);
        Task<bool> AddEmployee(EmployeeModel employee);
        Task<bool> AddEmployeeStatus(EmployeeStatus status);
    }
}
