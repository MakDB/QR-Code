using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QR_Material_Scanner.Models;
using QR_Material_Scanner.Pages.Account;
using QR_Material_Scanner.Helpers;

namespace QR_Material_Scanner.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;


        public LoginModel(
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

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "RememberMe")]
            public bool RememberMe { get; set; }
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



        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/home");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(Input.UserName);
                    _logger.LogInformation("User logged in.");
                  
                    //return Redirect(returnUrl);
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {

                        //HttpContext.Session.SetString("UserName", Input.UserName);

                        Set("UserName", ConvertStringToBase64String(Input.UserName.ToLower()));
                        Set("Plant", ConvertStringToBase64String(user.Plant));

                        //return RedirectToPage("./Index");
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Page();
                    }
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWithTwoFactor", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    //ModelState.AddModelError(string.Empty, _localizer["InvalidLoginAttempt"]);
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


        public  void Set(string key, string value, int? expireTime = null)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                 option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
                //option.Expires = DateTime.Now.AddMinutes(expireTime);
            else
                option.Expires = DateTime.Today.AddDays(1);
            

            Response.Cookies.Append(key, value, option);
        }

        public  string ConvertStringToBase64String(string Value)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(Value);
            var Encode = System.Convert.ToBase64String(plainTextBytes);
            return Encode;
        }

        public string ConvertBase64StringToString(string Value)
        {
            byte[] data = System.Convert.FromBase64String(Value);
            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
            return base64Decoded;

        }
    }
}