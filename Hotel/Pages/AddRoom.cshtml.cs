using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class AddRoomModel : PageModel
    {
        private readonly ILogger<AddRoomModel> _logger;
        private readonly dbclass _t1;
        public AddRoomModel(ILogger<AddRoomModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }

        [BindProperty]
        public string CategoryName { get; set; }

        [BindProperty]
        public int Roomn { get; set; }
        [BindProperty]
        public int Price { get; set; }
        [BindProperty]
        
        public string message { get; set; }

        public void OnGet()
        {
            Table = _t1.ShowTable("RoomType");

        }
        public IActionResult OnPostSubmit()
        {
            
            message = _t1.InsertRoom(Roomn, CategoryName, Price);
            return RedirectToPage("/Admin");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Admin");

        }
    }
}
