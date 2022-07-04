using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QR_Material_Scanner.Models;
using QR_Material_Scanner.Services;

namespace QR_Material_Scanner.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMailService _emailSender;

       

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IMailService emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

               

                var callbackUrl = Url.Page(
                    "/ResetPassword",
                    pageHandler: null,
                    values: new { Input.Email,token },
                    protocol: Request.Scheme);

                //var MailMessage = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                var MailMessage = $"<p>Greetings from Ariston Thermo!</p><p>We received a request to reset the password associated with this email address. If you made this request, please follow the instructions below.</p><p>If you weren't trying to reset your password, don't worry - your account is still secure and no one has been given access to it. You can safely ignore this email.</p><br><p>To reset your account password, simply <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click here</a>. It will take you to a web page where you can create a new password.</p><p>Please note that the link will expire 2 hours after this email was sent.</p><p>It has been our pleasure to help you. </p><p>Regards,<br>Ariston Thermo India Pvt Ltd.</p>";
                await _emailSender.SendEmailAsync(
                    Input.Email,
                    "QR Scanner App - Reset Password",
                    MailMessage);

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
