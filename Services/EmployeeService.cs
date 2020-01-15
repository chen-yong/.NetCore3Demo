using Student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> employees = new List<Employee>();
        public EmployeeService()
        {
            employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName="Nick",
                LastName="Carter",
                Gender=Gender.男
            });
            employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Miachel",
                LastName = "Jackson",
                Gender = Gender.女
            });
            employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FirstName = "Mariah",
                LastName = "Carey",
                Gender = Gender.男
            });
        }
        public Task<Employee> Fire(int id)
        {
            return Task.Run(function: () =>
             {
                 var employee = employees.FirstOrDefault(e => e.Id == id);
                 if (employee != null) 
                 {
                     employee.Fired = true;
                     return employee;
                 }
                 return null;
             }
            );
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(function: () => employees.Where(x=>x.DepartmentId==departmentId));
        }

        public Task Add(Employee employee)
        {
            employee.Id = employees.Max(x => x.Id) + 1;
            employees.Add(employee);
            return Task.CompletedTask;
        }
    }
}
