using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementEF.Models {
    public class EmployeeModel {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Phone number must contain only digits.")]
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Designation { get; set; }
        public int DepartmentID { get; set; }
        public string ManagerID { get; set; }
        public string Status { get; set; }
    }
}
