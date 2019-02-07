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

        //Returns Control Span for Employee Instance
        public int GetControlSpan()
        {
            var controlSpan = GetSalary();

                var subs = GetSubordinates();

                foreach (var s in subs)
                {
                    controlSpan += s.GetSalary();

                    foreach (var i in s.GetSubordinates())
                    {
                        controlSpan += i.GetSalary();

                        foreach (var j in i.GetSubordinates())
                        {
                            controlSpan += j.GetSalary();

                            foreach (var k in j.GetSubordinates())
                            {
                                controlSpan += k.GetSalary();

                                foreach (var l in k.GetSubordinates())
                                {
                                    controlSpan += l.GetSalary();

                                    foreach (var m in l.GetSubordinates())
                                    {
                                        controlSpan += l.GetSalary();

                                        foreach (var n in m.GetSubordinates())
                                        {
                                            controlSpan += m.GetSalary();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return controlSpan;
        }

        override
        public String ToString()
        {
            return ("Id : " + _id + " ,Name : " + _name + ", Position : " + _position + ", Salary :" + _salary + " ");
        }
    }
}
