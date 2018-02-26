using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular5CRI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular5CRI.Controllers
{
    
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        // GET: api/<controller>
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Get()
        {
            return objemployee.GetAllEmployee();
        }

      

        // POST api/<controller>
        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] Employee employee)
        {
            return objemployee.AddEmployee(employee);
        }

       
    }
}
