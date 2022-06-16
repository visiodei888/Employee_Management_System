﻿using EmployeeManagement.Data;
using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeBuisness employeeBusiness;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            employeeBusiness = new EmployeeBuisness();
        }

        [HttpGet("GetAllEmployee")]
        public async Task<List<EmployeeGetByIdModel>> GetAllEmployee()
        {
            return await employeeBusiness.GetAllEmployeesAsync();
        }
        [HttpGet(Name = "GetEmployee")]
        public async Task<IActionResult> GetById(int Id)
        {
            var employee = await employeeBusiness.GetEmployeeAsync(Id);

            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest(employee);
            }
        }


        //model

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var employees = await employeeBusiness.GetEmployeeListAsync(Id);

            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return BadRequest(employees);
            }
        }



        [HttpGet("FetchAllEmployeeByGender")]
        public async Task<IActionResult> FetchAllEmployeeByGender(String gender)
        {
            var employees =  employeeBusiness.FetchAllEmployeesAsync(gender);

            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return BadRequest(employees);
            }
        }


        [HttpPost(Name = "SaveEmployee")]
        public async Task<HttpStatusCode> SaveEmployee(EmployeeCreateModel employee)
        {
            return await employeeBusiness.SaveEmployeeAsync(employee);
        }
        [HttpPut(Name = "UpdateEmployee")]
        public async Task<HttpStatusCode> UpdateEmployee(Employee employee)
        {
            return await employeeBusiness.UpdateEmployeeAsync(employee);
        }
        [HttpDelete(Name = "DeeleteEmployee")]
        public async Task<IActionResult> DeleteById(int employeeId)
        {
            var employee =  employeeBusiness.DeleteEmployeeAsync(employeeId);
            return Ok(employee);
        }
    }
}
