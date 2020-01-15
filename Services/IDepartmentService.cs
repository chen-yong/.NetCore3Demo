using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Models;

namespace Student.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task<CompanySummary> GetCompanySummary();
        Task Add(Department department);

    }
}
