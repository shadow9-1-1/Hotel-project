using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Hotel.Pages
{
    public class serviceModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public serviceModel(ILogger<IndexModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            Table = t1.ShowTable("Services");
        }
        
    }
}
