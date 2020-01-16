using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        [Display(Name = "姓")]
        public string FirstName { get; set; }
        [Display(Name = "名")]
        public string LastName { get; set; }
        [Display(Name = "性别")]
        public Gender Gender { get; set; }
        [Display(Name = "解雇")]
        public bool Fired { get; set; }
    }
    public enum Gender
    {
        女 = 0,
        男 = 1,
    }
}
