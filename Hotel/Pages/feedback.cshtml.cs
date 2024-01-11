using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Data;
using Hotel.Model;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.Pages
{
    public class feedbackModel : PageModel
    {
        private ILogger<feedbackModel> _logger;
        private dbclass t1;
        

        [BindProperty]
        [Required]
        public string feedback { get; set; }
        [BindProperty]
        public int rate { get; set; }
        
        public string st { get; set; }
        public DataTable Table { get; set; }
        public string Username1 { get; set; }
        public feedbackModel(ILogger<feedbackModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.Username;
            Table = t1.ShowFeadbackTable();
        }
        public IActionResult OnPostSubmit()
        {
            Table = t1.ShowFeadbackTable();
            /*if (ModelState.IsValid)
            {
                st = t1.InsertFeedback((Table.Rows.Count+1), Username1,DateTime.Now,feedback,rate);
               
                return RedirectToPage("/Userpage");

            }*/
            st = t1.InsertFeedback(Table.Rows.Count + 1, t1.Username, DateTime.Now, feedback, rate);
            return RedirectToPage("/Userpage");
            //return Page();
        }
    }
}
