using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Employee
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class SearchModel : PageModel
    {
        public string op;
        public void OnGet(string id)
        {
            op = id;
        }
    }
}
