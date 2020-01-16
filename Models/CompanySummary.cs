using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Models
{
    public class CompanySummary
    {
        /// <summary>
        /// 员工总数
        /// </summary>
        public int EmpolyeeCount { get; set; }
        /// <summary>
        /// 部门的平均人数
        /// </summary>
        public int AverageDepartmentEmployeeCount { get; set; }
    }
}
