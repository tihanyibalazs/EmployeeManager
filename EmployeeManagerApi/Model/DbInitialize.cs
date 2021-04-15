using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EmployeeManagerApi.Model
{
    public class DbInitialize
    {
        private static EmployeeManagerContext DbContext;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            DbContext = serviceProvider.GetRequiredService<EmployeeManagerContext>();

            DbContext.Database.Migrate();

            if (DbContext.Employees.Any())
                return;

            SeedDatabase();
        }

        public static void SeedDatabase()
        {
            Guid newUUID = Guid.NewGuid();
            var employee1 = new Employee()
            {
                Name = "Example Joe",
                Email = "joe@gmail.com",
                JobTitle = "mechanic",
                PhoneNumber = "09407389274",
                ImageUrl = "https://bootdey.com/img/Content/avatar/avatar1.png",
                EmployeeCode = newUUID.ToString()
            };

            newUUID = Guid.NewGuid();
            var employee2 = new Employee()
            {
                Name = "Example Rose",
                Email = "rose@gmail.com",
                JobTitle = "programmer",
                PhoneNumber = "09405389672",
                ImageUrl = "https://bootdey.com/img/Content/avatar/avatar3.png",
                EmployeeCode = newUUID.ToString()
            };

            DbContext.Employees.Add(employee1);
            DbContext.Employees.Add(employee2);

            DbContext.SaveChanges();
        }

        /*
         * Hello Git!
         */
    }
}
