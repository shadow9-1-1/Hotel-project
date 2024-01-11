/*using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Hotel.Pages
{
    public class signupModel : PageModel
    {
        
        [BindProperty]
        [Required]
        public string username { get; set; }
        [BindProperty]
        [Required]
        public string name { get; set; }
        [BindProperty]
        [Required]
        public string email { get; set; }
        [BindProperty]
        [Required]
        public string pass { get; set; }
        
        public string usererror { get; set; }
        public string guest { get; set; }

        private ILogger<IndexModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        public signupModel(ILogger<IndexModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Table = t1.ShowTable("Guest");
            for (int i = 0; i < Table.Rows.Count; i++)
            {
                if (username == Table.Rows[i][0])
                {
                    usererror = "username unavalple";
                    return Page();
                }
            }
            guest = t1.SignUp(username, pass, name, email);
            return RedirectToPage("/Login SingUp");
            *//*if (ModelState.IsValid)
            {
                Table = t1.ShowTable("Guest");
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    if (username == Table.Rows[i][0])
                    {
                        usererror = "username unavalple";
                        return Page();
                    }
                }
                guest=t1.SignUp(username,pass,name,email);
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }*//*
        }
    }
}
*/
using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Hotel.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string UserError { get; set; }
        public string Guest { get; set; }

        private readonly ILogger<signupModel> _logger;
        private readonly dbclass _t1;

        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public signupModel(ILogger<signupModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Table = _t1.ShowTable("Guest");
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    if (Username.Equals(Table.Rows[i][0].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        UserError = "Username unavailable";
                        return Page();
                    }
                }

                Guest = _t1.SignUp(Username, Password, Name, Email);
                return RedirectToPage("/Login SingUp");
            }

            return Page();
        }
    }
}
