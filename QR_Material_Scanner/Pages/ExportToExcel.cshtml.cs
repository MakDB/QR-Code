using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QR_Material_Scanner.Models;
using QR_Material_Scanner.Pages.Account;

namespace QR_Material_Scanner.Pages
{
    public class ExportToExcelModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;


        public ExportToExcelModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }



        public class InputModel : IValidatableObject
        {
            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime FromDate { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime ToDate { get; set; }


            // This is for server side protection
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (ToDate < FromDate)
                {
                    yield return new ValidationResult(errorMessage: "End Date cannot be lesser than Start Date.", memberNames: new[] { "EndDate" });
                }
            }
        }
        public IActionResult OnGet(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/home");
            try
            {

                // Verification.  
                if (this.User.Identity.IsAuthenticated)
                {
                    // Home Page.  
                    _logger.LogInformation("User Already logged in.");
                    return Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.Page();
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
            
            }
            return Page();
        }
    }
}
