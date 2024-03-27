using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeManagementEF.Data.Models {
    public class Employee {
        [Key]
        public Guid EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        [StringLength(20)] // Adjust the maximum length as needed
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Phone number must contain only digits.")]
        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public DateTime DateOfJoining { get; set; }
        public string Designation { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }

        [ForeignKey("Employee")]
        public Guid? ManagerID { get; set; }

        public string Status { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Employee? Manager { get; set; }
    }
}
