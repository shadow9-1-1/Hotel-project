using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Hotel.Pages
{
    public class reservationModel : PageModel
    {
        public string username { get; set; }
        [BindProperty]
        [Required]
        public string Room { get; set; }
        [BindProperty]
        [Required]
        public string Servicse { get; set; }
        [BindProperty]
        [Required]
        public DateTime checkin { get; set; }
        [BindProperty]
        [Required]
        public DateTime checkout { get; set; }
        [BindProperty]
        [Required]
        public int RoomN { get; set; }
        private ILogger<reservationModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        public DataTable Table3 { get; set; }
        public string test { get; set; }

        public reservationModel(ILogger<reservationModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            Table = t1.ShowTable("RoomType");
            Table1 = t1.ShowTable("Room");
            Table2 = t1.ShowTable("Services");
            Table3 = t1.ShowTable("Reservation");
            username = t1.Username;


        }
        public IActionResult OnPostSubmit()
        {

            Table3 = t1.ShowTable("Reservation");
            test =t1.InsertReservation(Table3.Rows.Count+1, RoomN,t1.Username, checkin, checkout);
            return RedirectToPage("/Userpage");

            
        }
    }
}
