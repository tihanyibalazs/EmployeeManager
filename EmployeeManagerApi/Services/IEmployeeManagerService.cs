using EmployeeManagerApi.Model;
using System.Collections.Generic;

namespace EmployeeManagerApi.Services
{
    public interface IEmployeeManagerService
    {
        List<Employee> GetAllEmployee();
        Employee UpdateEmployee(Employee employee);
        Employee AddNewEmployee(Employee employee);
        void DeleteEmployee(int id);
        Employee FindEmployeeById(int id);
    }
}
