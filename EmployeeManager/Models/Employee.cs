using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        private int _id;
        private String _name;
        private String _position;
        private int _salary;
        private int _controlSpan;
        private int? _parentId;
        private int _tier;
        private List<Employee> _subordinates;

        // constructor
        public Employee(int id, String name, String position, int sal, int? parentId)
        {
            _id = id;
            _name = name;
            _position = position;
            _salary = sal;
            _parentId = parentId;
            _subordinates = new List<Employee>();
        }

        public void Add(Employee e)
        {
            _subordinates.Add(e);
        }


        private int TraverseTree(Employee e)

        {
            _controlSpan += e.GetSalary();

            List<Employee> employees = e.GetSubordinates();

            foreach (Employee employee in employees)
            {

                TraverseTree(employee);

            }

            return _controlSpan;
        }

        int TraverseTree()

        {

            return TraverseTree(this);

        }

        public void SetSpan(int controlSpan)
        {
            _controlSpan = controlSpan;
        }

        public int GetSpan()
        {
            SetSpan(0);
            return TraverseTree();
        }

        public void SetTier(int tier) { _tier = tier; }

        public int GetTier() { return _tier; }

        public int? GetParentId() { return _parentId; }

        public void Remove(Employee e)
        {
            _subordinates.Remove(e);
        }

        public List<Employee> GetSubordinates()
        {
            return _subordinates;
        }

        public int GetId() { return _id; }

        public string GetName() { return _name; }

        public string GetPosition() { return _position; }

        public int GetSalary() { return _salary; }

        override
        public String ToString()
        {
            return ("Id : " + _id + " ,Name : " + _name + ", Position : " + _position + ", Salary :" + _salary + " ");
        }
    }
}
