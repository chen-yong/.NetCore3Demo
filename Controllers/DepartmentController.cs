using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Student.Models;
using Student.Services;

namespace Student.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        //构造函数注入
        public DepartmentController(IDepartmentService departmentService,IOptions<ThreeOptions> threeOptions )
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            // 获取所有部门集合
            var departments = await _departmentService.GetAll();
            return View(departments);
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department model)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}