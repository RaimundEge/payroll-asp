using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Project
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ConfirmModel : PageModel
    {
        private ProjectStore store;
        public ConfirmModel(ProjectStore store)
        {
            this.store = store;
        }
        
         public void OnPost(int id)
        {
            ViewData["message"] = store.deleteProject(id);
        }
    }
}
