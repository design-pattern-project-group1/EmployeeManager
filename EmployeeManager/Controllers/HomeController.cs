using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Models;
using EmployeeManager.Services;

namespace EmployeeManager.Controllers
{
    public class HomeController : Controller
    {
        //Singelton Instance for _employeeRepository
        private IEmployeeRepository _employeeRepository = EmployeeRepository.AddSingleton();

        public HomeController()
        {

        }

        //Returns Home View
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                ViewBag.parentId = id;
                ViewBag.btfl = "Back to Full List";
                ViewBag.header = "[ |Subordinate List| ] :- of -: " + _employeeRepository.Get(id).ToString();
            }

            else
            {
                ViewBag.header = "Home - Full List";
            }

            if (id != null)
            {
                return View(_employeeRepository.Get(id).GetSubordinates());
            }

            return View(_employeeRepository.GetAll());
        }


        //Gets Add Interface/Page to Add subordinate to Employee
        [HttpGet]
        public IActionResult Add(int? id)
        {
            return View(_employeeRepository.Get(id));
        }

        //Adds subordinate to Employee
        [HttpPost]
        public IActionResult Add(int? superiorId, String name, String position, int salary)
        {
            Employee e = new Employee(
                _employeeRepository.GetAll().Max(i => i.GetId()) + 1,
                name,
                position,
                salary,
                superiorId
                );

            _employeeRepository.Add(e);
            _employeeRepository.Get(superiorId).Add(e);

            return RedirectToAction("Index", new { id = superiorId});
        }

        //Returns Tree View
        public IActionResult Tree()
        {
            List<List<List<Employee>>> all = 
                
                new List<List<List<Employee>>>
                {
                    new List<List<Employee>>
                    {
                        new List<Employee>
                        {
                            _employeeRepository.GetAll().FirstOrDefault(i => i.GetParentId().Equals(0))
                        }
                    }
                
                };

            for (int i = 0; i < _employeeRepository.GetAll().Max( j => j.GetTier()); i++)
            {
                all.Add(_employeeRepository.GetTierEmployees(i));
            }

            return View(all);
        }
    }
}
