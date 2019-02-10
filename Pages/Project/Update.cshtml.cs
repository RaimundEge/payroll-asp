using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Project
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class UpdateModel : PageModel
    {
        private ProjectStore store;
        public UpdateModel(ProjectStore store)
        {
            this.store = store;
        }
        [BindProperty]
        public Project proj { get; set; }

        [HttpPost("{id}")]
        public void OnPost(int id)
        {
            ViewData["action"] = (id == -1) ? "Create" : "Update";
            if (id == -1)
            {
                proj.Id = id;
            }
            ViewData["message"] = store.updateProject(proj);
        }
    }
}
