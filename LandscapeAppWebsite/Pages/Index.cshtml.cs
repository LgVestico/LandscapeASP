using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
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

        //First part of the link
        [BindProperty]
        public string Server { get; set; }

        public string ErrorMessage { get; set; }



        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(CurrentLink))
            {
                CurrentLink = null;
            }
        }


        public IActionResult OnPost()
        {
            //reset link, to prevent site from reloading old values
            CurrentLink = null;

            //Check whether input was correct 
            if (ModelState.IsValid == false || Server == null)
            {
                ErrorMessage = "Wrong Input";  
                return Page();
            }
            RM.UpdateValues(Server);
            CurrentLink = RM.URL;

            //reset error message & RequestManager values
            ErrorMessage = null;
            RM = new RequestManager();

            return RedirectToPage("./Index", new { CurrentLink  });
        }
    }
}
