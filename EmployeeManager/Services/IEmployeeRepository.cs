using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Services
{
    //Employee Repository Interface For Different Data Provider Services
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        Employee Get(int? id);

        Employee Add(Employee e);

        List<List<Employee>> GetTierEmployees(int tier);

        void Delete(Employee e);
    }
}
