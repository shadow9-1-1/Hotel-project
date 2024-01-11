using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Hotel.Pages
{
    public class loginHEModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserError { get; set; }
        [BindProperty]
        public string Select { get; set; }

        private readonly ILogger<loginHEModel> _logger;
        private readonly dbclass _t1;

        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public loginHEModel(ILogger<loginHEModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Select == "Admin")
            {
                if (ModelState.IsValid)
                {
                    Table = _t1.ShowTable("Admin");
                    for (int i = 0; i < Table.Rows.Count; i++)
                    {
                        if (Username == Table.Rows[i]["UserName"].ToString() && Password == Table.Rows[i]["Password"].ToString())
                        {
                            _t1.Ausername1(Username);
                            return RedirectToPage("/Admin");


                        }
                    }
                }
                UserError = "Username or password are incorrect";
                return Page();
            }
            else if(Select== "Manager")
            {
                if (ModelState.IsValid)
                {
                    Table = _t1.ShowTable("Manager");
                    for (int i = 0; i < Table.Rows.Count; i++)
                    {
                        if (Username == Table.Rows[i]["UserName"].ToString() && Password == Table.Rows[i]["Password"].ToString())
                        {
                            _t1.Ausername1(Username);
                            return RedirectToPage("/Manager");


                        }
                    }
                }
                UserError = "Username or password are incorrect";
                return Page();
            }
            else if (Select == "Staff")
            {
                if (ModelState.IsValid)
                {
                    Table = _t1.ShowTable("Staff");
                    for (int i = 0; i < Table.Rows.Count; i++)
                    {
                        if (Username == Table.Rows[i]["SUsername"].ToString() && Password == Table.Rows[i]["Password"].ToString())
                        {
                            _t1.Ausername1(Username);
                            return RedirectToPage("/Staff");


                        }
                    }
                }
                UserError = "Username or password are incorrect";
                return Page();
            }
            
            
            UserError = "Select Your Role First";
            return Page();


        }
        
    }
}
