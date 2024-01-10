using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

namespace Hotel.Pages
{
    public class Login_SingUpModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserError { get; set; }
        public string Guest { get; set; }

        private readonly ILogger<Login_SingUpModel> _logger;
        private readonly dbclass _t1;

        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public Login_SingUpModel(ILogger<Login_SingUpModel> logger, dbclass t1)
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
                    if (Username == Table.Rows[i]["Username"].ToString() && Password == Table.Rows[i]["Password"].ToString())
                    {
                        _t1.username1(Username);
                        return RedirectToPage("/Userpage" , new {Username=Username});
                        
                        
                    }
                }
                

                
            }
            UserError = "Username or password are incorrect";
            return Page();


        }
    }
}
