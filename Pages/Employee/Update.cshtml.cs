using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace Payroll.Pages.Employee
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class UpdateModel : PageModel
    {  
        private EmployeeStore store;
        public UpdateModel(EmployeeStore store) {
            this.store = store;
        }
        [BindProperty]
        public Employee emp { get; set; }

        [HttpPost("{id}")]
        public void OnPost(int id)
        {
            ViewData["action"] = (id == -1) ? "Create" : "Update";
            if (id == -1) {
                emp.Id = id;
            }
            ViewData["message"] = store.updateEmployee(emp);
        }
    }
}
