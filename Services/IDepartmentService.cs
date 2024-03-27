using EmployeeManagementEF.Data.Models;

namespace EmployeeManagementEF.Services
{
    public interface IDepartmentService {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int DepartmentID);
        Task<bool> AddDepartment(Department department);
    }
}
