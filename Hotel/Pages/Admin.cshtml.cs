using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel.Pages
{
    public class AdminModel : PageModel
    {
        private ILogger<AdminModel> _logger;
        private dbclass t1;

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        [BindProperty]
        public string Username1 { get; set; }

        public AdminModel(ILogger<AdminModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;
        }
        public IActionResult OnPostSubmit()
        {

            return RedirectToPage("/Manager");
        }
        public IActionResult OnPostSubmit1()
        {

            return RedirectToPage("/AddManager");
        }
        public IActionResult OnPostSubmit2()
        {

            return RedirectToPage("/AddStaff");
        }
        public IActionResult OnPostSubmit3()
        {

            return RedirectToPage("/AddAdmin");
        }
        public IActionResult OnPostSubmit4()
        {

            return RedirectToPage("/AddRoomType");
        }
        public IActionResult OnPostSubmit5()
        {

            return RedirectToPage("/AddServes");
        }
        public IActionResult OnPostSubmit6()
        {

            return RedirectToPage("/AddRoom");
        }

    }
}
