using EmployeeManagementEF.Data.Models;
using EmployeeManagementEF.Models;
using EmployeeManagementEF.Services;

namespace EmployeeManagementEF.Helpers {
    public static class SeedHelper {

        public async static Task SeedData(IDepartmentService departmentService, IEmployeeService employeeService) {
            await SeedDepartments(departmentService);
            await SeedManagers(employeeService);
        }

        private async static Task SeedDepartments(IDepartmentService departmentService) {


            if (await departmentService.GetDepartmentByIdAsync(1) is null) {
                Department Developers = new Department() {
                    DepartmentID = 1,
                    Name = "Managers"
                };
                await departmentService.AddDepartment(Developers);
            }

            if (await departmentService.GetDepartmentByIdAsync(2) is null) {
                Department Developers = new Department() {
                    DepartmentID = 2,
                    Name = "Developers"
                };
                await departmentService.AddDepartment(Developers);
            }

            if (await departmentService.GetDepartmentByIdAsync(3) is null) {
                Department QualityService = new Department() {
                    DepartmentID = 3,
                    Name = "Quality Service"
                };
                await departmentService.AddDepartment(QualityService);
            }

            if (await departmentService.GetDepartmentByIdAsync(4) is null) {
                Department OfficeStaff = new Department() {
                    DepartmentID = 4,
                    Name = "Office Staff"
                };
                await departmentService.AddDepartment(OfficeStaff);
            }
        }

        private async static Task SeedManagers(IEmployeeService employeeService) {

            if (await employeeService.GetEmployeeByEmailAsync("arun@rheal.com") is null) {
                EmployeeModel NewManager = new EmployeeModel() {
                    EmployeeID = new Guid().ToString(),
                    FirstName = "Arun",
                    MiddleName = "",
                    LastName = "Jadhav",
                    DateOfBirth = new DateTime(year: 1989, month: 01, day: 01),
                    Phone = "+918965368954",
                    Email = "arun@rheal.com",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    PostalCode = "425878",
                    DateOfJoining = new DateTime(year: 2002, month: 01, day: 01),
                    DepartmentID = 1,
                    Designation = "Project Manager",
                    Status = "Active"
                };
                await employeeService.AddEmployee(NewManager);
            }

            if (await employeeService.GetEmployeeByEmailAsync("ramnath@rheal.com") is null) {
                EmployeeModel NewManager = new EmployeeModel() {
                    EmployeeID = new Guid().ToString(),
                    FirstName = "Ramnath",
                    MiddleName = "",
                    LastName = "Iyer",
                    DateOfBirth = new DateTime(year: 1990, month: 01, day: 01),
                    Phone = "+919955368954",
                    Email = "ramnath@rheal.com",
                    City = "Bengaluru",
                    State = "Karnataka",
                    Country = "India",
                    PostalCode = "895879",
                    DateOfJoining = new DateTime(year: 2003, month: 01, day: 01),
                    DepartmentID = 1,
                    Designation = "Project Manager",
                    Status = "Active"
                };
                await employeeService.AddEmployee(NewManager);
            }

            if (await employeeService.GetEmployeeByEmailAsync("ravindra@rheal.com") is null) {
                EmployeeModel NewManager = new EmployeeModel() {
                    EmployeeID = new Guid().ToString(),
                    FirstName = "Ravindra",
                    MiddleName = "",
                    LastName = "Sonone",
                    Phone = "+918456368954",
                    DateOfBirth = new DateTime(year: 1989, month: 06, day: 09),
                    Email = "ravindra@rheal.com",
                    City = "Pune",
                    State = "Maharashtra",
                    Country = "India",
                    PostalCode = "422547",
                    DateOfJoining = new DateTime(year: 2008, month: 01, day: 01),
                    DepartmentID = 1,
                    Designation = "Project Manager",
                    Status = "Active"
                };
                await employeeService.AddEmployee(NewManager);
            }

            if (await employeeService.GetEmployeeByEmailAsync("darrell@rheal.com") is null) {
                EmployeeModel NewManager = new EmployeeModel() {
                    EmployeeID = new Guid().ToString(),
                    FirstName = "Darrell",
                    MiddleName = "",
                    LastName = "Fernandes",
                    Phone = "+917586368954",
                    DateOfBirth = new DateTime(year: 1992, month: 12, day: 06),
                    Email = "darrell@rheal.com",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    PostalCode = "427549",
                    DateOfJoining = new DateTime(year: 2012, month: 01, day: 01),
                    DepartmentID = 1,
                    Designation = "Project Manager",
                    Status = "Active"
                };
                await employeeService.AddEmployee(NewManager);
            }

        }
    }
}
