using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementEF.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentID { get; set; }
        public string Name { get; set; }

    }
}
