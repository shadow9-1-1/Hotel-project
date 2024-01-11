using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class AddAdminModel : PageModel
    {
        private readonly ILogger<AddAdminModel> _logger;
        private readonly dbclass _t1;
        public AddAdminModel(ILogger<AddAdminModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }

        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public string message { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPostSubmit()
        {
            message = _t1.InsertAdmin(username, password);
            return RedirectToPage("/Admin");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Admin");

        }
    }
}
