using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Employee
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ListModel : PageModel
    {
        private EmployeeStore store;
        public ListModel(EmployeeStore store)
        {
            this.store = store;
        }

        public List<Employee> employees;
        public List<Payroll.Pages.Project.Project> projects;
        //private ProjectStore projStore = new ProjectStore();
        public string op;
        public void OnPost(string op, string search)
        {
            this.op = op;
            employees = store.FindEmployees(search);
            //dotprojects = projStore.FindProjects("");  
        }

    }
}
