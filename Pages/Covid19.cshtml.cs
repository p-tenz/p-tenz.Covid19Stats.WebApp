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
    public class Covid19Model : PageModel
    {
        private readonly ILogger<Covid19Model> _logger;

        public string Title { get; internal set; }
        public string SubTitle { get; internal set; }
        public List<CasesModels.Feature> covid19Data { get; set; }

        public Covid19Model(ILogger<Covid19Model> logger)
        {
            _logger = logger;
            ApiHelper.InitializeClient();

        }
        

        public async Task<IActionResult> OnGetAsync()
        {
            this.Title = "Covid-19 Fälle in Stuttgart";

            covid19Data = await CasesController.LoadCovidData();
            this.SubTitle = covid19Data.FirstOrDefault().attributes.Datenstand;
            

            return Page();
        }
    }
}
