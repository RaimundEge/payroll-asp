using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Project
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EditModel : PageModel
    {
        private ProjectStore store;
        public EditModel(ProjectStore store)
        {
            this.store = store;
        }
        
        public Project project;
        public void OnGet(int id)
        {
            if (id == -1) {
                ViewData["action"] = "Create";
                project = new Project
                {
                    Id = -1
                };
            }
            else
            {
                ViewData["action"] = "Update";
                project = store.getProject(id);
            }

        }
    }
}
