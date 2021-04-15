using EmployeeManagerApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagerApi.Services
{
    public class EmployeeManagerService : IEmployeeManagerService
    {
        private EmployeeManagerContext DbContext;
        public EmployeeManagerService(EmployeeManagerContext context)
        {
            DbContext = context;
        }

        public Employee AddNewEmployee(Employee newEmployee)
        {
            Guid newUUID = Guid.NewGuid();
            newEmployee.EmployeeCode = newUUID.ToString();
            DbContext.Employees.Add(newEmployee);
            DbContext.SaveChanges();
            return newEmployee;
        }

        public void DeleteEmployee(int id)
        {
            var employeeToDelete = DbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            DbContext.Employees.Remove(employeeToDelete);
            DbContext.SaveChanges();
        }

        public Employee UpdateEmployee(Employee employeeNewData)
        {
            var employeeToUpdate = DbContext.Employees.Where(x => x.Id == employeeNewData.Id).FirstOrDefault();
            employeeToUpdate.Name = employeeNewData.Name;
            employeeToUpdate.Email = employeeNewData.Email;
            employeeToUpdate.JobTitle = employeeNewData.JobTitle;
            employeeToUpdate.PhoneNumber = employeeNewData.PhoneNumber;
            employeeToUpdate.ImageUrl = employeeNewData.ImageUrl;
            DbContext.SaveChanges();
            return employeeToUpdate;
        }
        public List<Employee> GetAllEmployee()
        {
            return DbContext.Employees.ToList();
        }
        public Employee FindEmployeeById(int id)
        {
            var findEmployee = DbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (findEmployee == null)
                throw new EmployeeNotFoundException("Employee was not found, id: " + id.ToString());
            return findEmployee;
        }
    }
}
