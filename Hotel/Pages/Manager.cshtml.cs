using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class ManagerModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        
        public string Username1 { get; set; }

        private readonly ILogger<ManagerModel> _logger;
        private readonly dbclass _t1;
        public ManagerModel(ILogger<ManagerModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }
        public DataTable Table5 { get; set; }
        public DataTable Table6 { get; set; }
        public DataTable Table7 { get; set; }
        public DataTable Table8 { get; set; }
        public DataTable Table9 { get; set; }
        public DataTable Table10 { get; set; }
        public void OnGet()
        {
            Username1 = _t1.AUsername;

            Table = _t1.ShowTable("Admin");
            Table2 = _t1.ShowTable("Manager");
            Table3 = _t1.ShowTable("Staff");
            Table4 = _t1.ShowTable("Guest");
            Table5 = _t1.ShowTable("RoomType");
            Table6 = _t1.ShowTable("Room");
            Table7 = _t1.ShowTable("Reservation");
            Table8 = _t1.ShowTable("RoomManager");
            Table9 = _t1.ShowTable("Services");
            Table10 = _t1.ShowTable("Feedback");

        }

    }
}
