using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class AddServesModel : PageModel
    {
        private readonly ILogger<AddServesModel> _logger;
        private readonly dbclass _t1;
        public AddServesModel(ILogger<AddServesModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }

        [BindProperty]
        public string ServesName { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string icon { get; set; }
        [BindProperty]
        public int Price { get; set; }
        
        
        [BindProperty]
        public string message { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPostSubmit()
        {
            Table = _t1.ShowTable("Serves");
            message = _t1.InsertService(Table.Rows.Count + 1, ServesName, Description, 1,Price, icon);
            return RedirectToPage("/Admin");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Admin");

        }
    }
}
