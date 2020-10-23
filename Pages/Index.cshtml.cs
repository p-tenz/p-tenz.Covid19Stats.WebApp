using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using p_tenz.Covid19Stats.ApiLib;

namespace p_tenz.Covid19Stats.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            ApiHelper.InitializeClient();
        }

        public string Title { get; internal set; }
        public string SubTitle { get; internal set; }
        public List<CasesModels.Feature> covid19Data { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            this.Title = "Covid-19 Fälle in Stuttgart";

            covid19Data = await CasesController.LoadCovidData();
            this.SubTitle = covid19Data.FirstOrDefault().attributes.Datenstand;


            return Page();
        }
    }
}
