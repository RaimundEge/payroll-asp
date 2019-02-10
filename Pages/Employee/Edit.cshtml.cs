using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Payroll.Pages.Project;

namespace Payroll.Pages.Employee
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EditModel : PageModel
    {
        private EmployeeStore store;
        private ProjectStore projStore;
        
        public EditModel(EmployeeStore store, ProjectStore projStore)
        {
            this.store = store;
            this.projStore = projStore;
        }

        public Employee employee;
        public List<Payroll.Pages.Project.Project> projects;
        public void OnGet(int id)
        {
            if (id == -1)
            {
                ViewData["action"] = "Create";
                employee = new Employee
                {
                    Id = -1
                };
            }
            else
            {
                ViewData["action"] = "Update";
                employee = store.getEmployee(id);
            }
            projects = projStore.FindProjects("");
        }
    }
}
