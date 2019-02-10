using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Employee
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ConfirmModel : PageModel
    {
        private EmployeeStore store;
        public ConfirmModel(EmployeeStore store)
        {
            this.store = store;
        }

        public void OnPost(int id)
        {
            ViewData["message"] = store.deleteEmployee(id);
        }
    }
}
