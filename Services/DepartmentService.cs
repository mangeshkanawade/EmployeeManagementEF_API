using EmployeeManagementEF.Data;
using EmployeeManagementEF.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementEF.Services
{
    public class DepartmentService : IDepartmentService {
        private readonly AppDBContext _dbContext;
        public DepartmentService(AppDBContext _appDBContext) {
            _dbContext = _appDBContext;
        }

        async Task<bool> IDepartmentService.AddDepartment(Department department) {

            if (_dbContext is null) return false;

            await _dbContext.AddAsync(department);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        async Task<Department> IDepartmentService.GetDepartmentByIdAsync(int DepartmentID) {
            if (_dbContext is null) return null;

            return await _dbContext.Departments.FindAsync(DepartmentID);
        }

        async Task<IEnumerable<Department>> IDepartmentService.GetDepartmentsAsync() {
            if (_dbContext is null) return null;

            return await _dbContext.Departments.ToListAsync();
        }
    }
}
