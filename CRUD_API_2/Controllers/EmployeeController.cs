using CRUD_API_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_API_2.Controllers
{
    public class EmployeeController : ApiController
    {

        //EmployeeRepository _repository = new EmployeeRepository();

        private  IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var employee = _repository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        public IHttpActionResult Post(Employee employee)
        {
            _repository.Post(employee);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        public IHttpActionResult Put(int id, Employee employee)
        {
            _repository.Put(id, employee);
            if (employee == null ) //add id filter
            {
                return NotFound();
            }
            return Ok(employee);
        }

        public string Delete(int id)
        {
            return _repository.Delete(id);
        }

    }
}
