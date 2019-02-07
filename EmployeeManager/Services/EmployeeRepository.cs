using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static EmployeeRepository instance = new EmployeeRepository();
        private List<Employee> _employees;

        private EmployeeRepository()
        {

            Employee CEO =
                new Employee(1, "John", "CEO", 30000, 0);
            CEO.SetTier(0);

            Employee VPMarketing = 
                new Employee(2, "Robert", "Head Marketing", 20000, CEO.GetId());
            VPMarketing.SetTier(1);

            Employee VPManufacturing = 
                new Employee(3, "Michel", "Head Manufacturing", 20000, CEO.GetId());
            VPManufacturing.SetTier(1);

            Employee VPSales = 
                new Employee(4, "Laura", "Head Sales", 20000, CEO.GetId());
            VPSales.SetTier(1);

            Employee MarketingExec1 = 
                new Employee(5, "Richard", "Marketing", 10000, VPMarketing.GetId());
            MarketingExec1.SetTier(2);

            Employee MarketingExec2 = 
                new Employee(6, "Rob", "Marketing", 10000, VPMarketing.GetId());
            MarketingExec2.SetTier(2);

            Employee SalesExec1 = 
                new Employee(7, "Scott", "Sales", 10000, VPSales.GetId());
            SalesExec1.SetTier(2);

            Employee SalesExec2 = 
                new Employee(8, "Hope", "Sales", 10000, VPSales.GetId());
            SalesExec2.SetTier(2);

            Employee ManufacturingExec1 = 
                new Employee(9, "Ada", "Manufacturing", 10000, VPManufacturing.GetId());
            ManufacturingExec1.SetTier(2);

            Employee ManufacturingExec2 = 
                new Employee(10, "Hank", "Manufacturing", 10000, VPManufacturing.GetId());
            ManufacturingExec2.SetTier(2);

            CEO.Add(VPSales);
            CEO.Add(VPMarketing);
            CEO.Add(VPManufacturing);

            VPSales.Add(SalesExec1);
            VPSales.Add(SalesExec2);

            VPMarketing.Add(MarketingExec1);
            VPMarketing.Add(MarketingExec2);

            VPManufacturing.Add(ManufacturingExec1);
            VPManufacturing.Add(ManufacturingExec2);


            _employees = new List<Employee>
            {
                CEO,
                VPMarketing,
                VPManufacturing,
                VPSales,
                MarketingExec1,
                MarketingExec2,
                SalesExec1,
                SalesExec2,
                ManufacturingExec1,
                ManufacturingExec2
            };
        }
        public Employee Add(Employee e)
        {
            e.SetTier(Get(e.GetParentId()).GetTier() + 1);
            _employees.Add(e);
            return e;
        }

        public List<Employee> AddAll(List<Employee> employees)
        {
            foreach (var e in employees)
            {
                Add(e);
            }

            return employees;
        }

        public List<List<Employee>> GetTierEmployees(int tier)
        {
            var NextTier = new List<List<Employee>>();

            var All = GetAll().Where(i => i.GetTier().Equals(tier));

            foreach (var item in All)
            {
                NextTier.Add(item.GetSubordinates());
            }

            return NextTier;
        }

        public void Delete(Employee e)
        {
            _employees.Remove(e);

        }

        public Employee Get(int? id)
        {
            return _employees.FirstOrDefault(i => i.GetId().Equals(id));
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public static EmployeeRepository AddSingleton()
        {
            return instance;
        }
    }
}
