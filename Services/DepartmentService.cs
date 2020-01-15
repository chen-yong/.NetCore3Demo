using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Models;

namespace Student.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> departments = new List<Department>();
        public DepartmentService()
        {
            departments.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                location = "Beijing"
            });
            departments.Add(new Department
            {
                Id = 2,
                Name = "R&D",
                EmployeeCount = 50,
                location = "Shanghai"
            });
            departments.Add(new Department
            {
                Id = 3,
                Name = "Sales",
                EmployeeCount = 100,
                location = "Hangzhou"
            });
        }
        public Task Add(Department department)
        {
            department.Id = departments.Max(x => x.Id) + 1;
            departments.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(function: () => departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(function: () => departments.FirstOrDefault(x => x.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(function: () =>
             {
                 return new CompanySummary
                 {
                     EmpolyeeCount = departments.Sum(x => x.EmployeeCount),
                     AverageDepartmentEmployeeCount = (int)departments.Average(x => x.EmployeeCount)
                 };
             }
            );
        }
    }
}
