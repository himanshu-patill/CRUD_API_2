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
        Entities db = new Entities();

        public IEnumerable<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            Employee employee = db.Employees.Find(id);
            return employee;

        }

        public Employee Post(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return employee;
        }

        public string Put(int id, Employee employee)
        {
            var employee_ = db.Employees.Find(id);

            employee_.name = employee.name;
            employee_.designation = employee.designation;
            employee_.salary = employee.salary;

            db.Entry(employee_).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return "Record Updated";
        }

        public string Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return "Record deleted";
        }



    }
}
