﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Services;

namespace Student.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await _departmentService.GetById(departmentId);
            //ViewBag.Title = $"Employees of {department.Name}";
            ViewBag.DepartmentId = departmentId;
            var employees = await _employeeService.GetByDepartmentId(departmentId);
            return View(employees);
        }
        public IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee
            {
                DepartmentId = departmentId
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }
            return RedirectToAction(nameof(Index),routeValues:new { departmentId=model.DepartmentId});
        }
        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await _employeeService.Fire(employeeId);
            return RedirectToAction(nameof(Index), routeValues: new { departmentId = employee.DepartmentId });
        }
    }
}