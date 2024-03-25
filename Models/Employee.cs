using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementEF.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeID {get; set;}
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName { get; set;}
        public string City { get; set;}
        public string State { get; set;}
        public string Country { get; set; }
        public string PostalCode { get; set;}
        public string Phone { get; set;}
        [EmailAddress]
        public string Email { get; set;}
        public DateTime DateOfJoining { get; set;}
        public string Designation { get; set;}
        [ForeignKey("Department")]
        public Guid? DepartmentID { get; set; }

        [ForeignKey("Employee")]
        public Guid? ManagerID { get; set;}
        public string Status { get; set;}
        public virtual Department Department { get; set;}
        public virtual Employee Manager { get; set; }
    }
}
