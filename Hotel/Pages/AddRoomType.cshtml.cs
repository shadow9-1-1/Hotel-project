using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class AddRoomTypeModel : PageModel
    {
        private readonly ILogger<AddRoomTypeModel> _logger;
        private readonly dbclass _t1;
        public AddRoomTypeModel(ILogger<AddRoomTypeModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }

        [BindProperty]
        public string CategoryName { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string photo { get; set; }
        [BindProperty]
        public int Price { get; set; }
        [BindProperty]
        public int bed { get; set; }
        [BindProperty]
        public int bath { get; set; }
        [BindProperty]
        public string message { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPostSubmit()
        {
            Table = _t1.ShowTable("RoomType");
            message = _t1.InsertRoomType(Table.Rows.Count + 1, CategoryName,Price, Description,bed,bath,photo);
            return RedirectToPage("/Admin");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Admin");

        }
    }
}
