using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name="部门名称")]
        public string Name { get; set; }
        [Display(Name = "部门数量")]
        public int EmployeeCount { get; set; }
        [Display(Name = "部门地址")]
        public string location { get; set; }
    }
}
