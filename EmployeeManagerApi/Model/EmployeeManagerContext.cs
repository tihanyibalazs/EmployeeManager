using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerApi.Model
{
    public class EmployeeManagerContext : DbContext
    {
        public EmployeeManagerContext(DbContextOptions<EmployeeManagerContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
