using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class ReservationHistoryModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        public string Username1 { get; set; }

        private readonly ILogger<ReservationHistoryModel> _logger;
        private readonly dbclass _t1;
        public ReservationHistoryModel(ILogger<ReservationHistoryModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }
        public void OnGet()
        {
            Username1 = _t1.Username;
            Table = _t1.ShowReservationHistoryTable(Username1);
        }
    }
}
