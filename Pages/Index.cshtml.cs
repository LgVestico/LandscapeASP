using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandscapeAppWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LandscapeAppWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public RequestManager RM { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentLink { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(CurrentLink))
            {
                CurrentLink = "Not defined";
            }
        }

        //typical output of post:
        public IActionResult OnPost()
        {
            //Check whether input was correct
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("./Index", new { CurrentLink = JoinLink() });//, new { RM.LorX });
        }

        private String JoinLink()
        {
            return RM.CoordX.ToString();
        }
    }
}
