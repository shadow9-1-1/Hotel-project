using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class AddStaffModel : PageModel
    {
        private readonly ILogger<AddStaffModel> _logger;
        private readonly dbclass _t1;
        public AddStaffModel(ILogger<AddStaffModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }
        public DataTable Table2 { get; set; }
        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }


        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public string manager { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string Admin { get; set; }
        [BindProperty]
        public string message { get; set; }

        public void OnGet()
        {
            Table = _t1.ShowTable("Admin");
            Table2 = _t1.ShowTable("Manager");
            Table3 = _t1.ShowTable("StafRoles");
        }
        public IActionResult OnPostSubmit()
        {
            Table4 = _t1.ShowTable("Staff");
            message = _t1.InsertStaff(Table4.Rows.Count+1,1,username,password,name,Role,manager,Admin);
            return RedirectToPage("/Admin");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Admin");

        }
        
    }
}
