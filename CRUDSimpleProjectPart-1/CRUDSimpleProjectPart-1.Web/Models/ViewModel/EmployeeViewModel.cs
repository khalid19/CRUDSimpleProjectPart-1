using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDSimpleProjectPart_1.Model;

namespace CRUDSimpleProjectPart_1.Web.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }


        public List<Employee> Employees { get; set; }


        public EmployeeViewModel()
        {
            Employee=new Employee();

            Employees=new List<Employee>();
        }
    }
}