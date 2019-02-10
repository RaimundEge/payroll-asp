using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Payroll.Pages.Project
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ListModel : PageModel
    {  
        private ProjectStore store;
        public ListModel(ProjectStore store)
        {
            this.store = store;
        }
         
        public List<Project> projects;     
        //private ProjectStore projStore = new ProjectStore();
        public string op;
        public void OnPost(string op, string search)
        {
            Console.WriteLine("in POST: " + op + " - " + search);
            this.op = op;
            projects = store.FindProjects(search); 
        }
        
    }
}
