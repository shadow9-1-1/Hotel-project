using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel.Pages
{
    public class UserpageModel : PageModel
    {
        private ILogger<UserpageModel> _logger;
        private dbclass t1;

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        [BindProperty]
        public string Username1 { get; set; }

        public UserpageModel(ILogger<UserpageModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.Username;
        }
        public IActionResult OnPostSubmit()
        {

            return RedirectToPage("/Updatedata");
        }
        public IActionResult OnPostSubmit1()
        {
            
            return RedirectToPage("/ReservationHistory");
        }
        public IActionResult OnPostSubmit2()
        {

            return RedirectToPage("/feedback");
        }
        public IActionResult OnPostSubmit3()
        {

            return RedirectToPage("/reservation");
        }
    }
}
