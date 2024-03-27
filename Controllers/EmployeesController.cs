using Microsoft.AspNetCore.Mvc;
using EmployeeManagementEF.Services;
using EmployeeManagementEF.Data.Models;
using EmployeeManagementEF.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() {
            try {
                var Employees = await _employeeService.GetEmployeesAsync();
                if (Employees == null) {
                    return NotFound();
                }
                return Ok(Employees);
            } catch (Exception ex) {
                return Problem(detail: ex.Message + " InnerException ==> " + ex?.InnerException?.Message, statusCode: 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetManagers() {
            try {
                var Employees = await _employeeService.GetManagersAsync();
                if (Employees == null) {
                    return NotFound();
                }
                return Ok(Employees);
            } catch (Exception ex) {
                return Problem(detail: ex.Message + " InnerException ==> " + ex?.InnerException?.Message, statusCode: 500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddEmployee([FromBody] EmployeeModel employee) {
            try {
                var isAdded = await _employeeService.AddEmployee(employee);

                if (!isAdded) {
                    return Problem(detail: "Unable to add Employee");
                }

                return Ok(isAdded);
            } catch (Exception ex) {
                return Problem(detail: ex.Message + " InnerException ==> " + ex?.InnerException?.Message, statusCode: 500);
            }
        }
    }
}
