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
    public class StatsModel : PageModel
    {
        private readonly ILogger<StatsModel> _logger;

        public DateTime Sunrise { get; internal set; }
        public DateTime Sunset { get; internal set; }
        public DateTime SolarNoon { get; internal set; }

        public string Title { get; internal set; }

        public StatsModel(ILogger<StatsModel> logger)
        {
            _logger = logger;
            ApiHelper.InitializeClient();
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            this.Title = "Stuttgart Sun";
            var sunData = await SunController.LoadSunData();
            this.Sunrise = sunData.Sunrise.ToLocalTime();
            this.Sunset = sunData.Sunset.ToLocalTime();
            this.SolarNoon = sunData.Solar_Noon.ToLocalTime();

            return Page();
        }
    }
}
