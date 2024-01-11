using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        public IndexModel(ILogger<IndexModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        
        

        
        
        public void OnGet()
        {
            Table = t1.ShowFeadbackTable();
            Table1 = t1.ShowTable("Services");
            Table2 = t1.ShowTable("RoomType");
        }
        
    }
}