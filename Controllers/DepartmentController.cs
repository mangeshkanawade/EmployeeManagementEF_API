using EmployeeManagementEF.Data.Models;
using EmployeeManagementEF.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            try
            {
                var Departments = await _departmentService.GetDepartmentsAsync();

                if (Departments == null)
                {
                    return NotFound();
                }

                return Ok(Departments);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message + " InnerException ==> " + ex?.InnerException?.Message, statusCode: 500);
            }
        }
    }
}
