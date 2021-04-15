using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerApi.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string EmployeeCode { get; set; }
    }
}
