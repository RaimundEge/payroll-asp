using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Employee
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class DeleteModel : PageModel
    {
        private EmployeeStore store;
        public DeleteModel(EmployeeStore store)
        {
            this.store = store;
        }

        public Employee employee;
        public void OnGet(int id)
        {
            employee = store.getEmployee(id);
        }
    }
}
