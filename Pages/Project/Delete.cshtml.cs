using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Project
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class DeleteModel : PageModel
    {
        private ProjectStore store;
        public DeleteModel(ProjectStore store)
        {
            this.store = store;
        }
        
        public Project project;
        public void OnGet(int id)
        {
            project = store.getProject(id);
        }
    }
}
