using EmployeeManagementEF.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementEF.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
