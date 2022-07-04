using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QR_Material_Scanner.Models;
using QR_Material_Scanner.Services;

namespace QR_Material_Scanner.Pages
{
    public class StoreLocatorModel : PageModel
    {
        private readonly IRepository _repository;
        private readonly IMailService _emailSender;
        public Middleware_Retailer retailer { get; set; }

        public StoreLocatorModel(IRepository repository, IMailService emailSender)
        {
            _repository = repository;
            _emailSender = emailSender;
        }

        [BindProperty]
        public Middleware_Retailer Input { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Input = _repository.GetRetailer(id.Value);
            }
       
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Retailer_Status retailer_Status = new Retailer_Status();

                retailer_Status = _repository.UpdateStoreLocator(Input);
                if (retailer_Status.Status_Code == "200")
                {
                    var messaage = "<p>Hi,</p><p>New Registered <strong>Store Locator </strong>details follow</p><table border='1' cellpadding='1' cellspacing='1' style='width: 500px'><tbody><tr><td>Name</td><td>Details</td></tr><tr><td>Business Name</td><td>" + Input.Business_Name + "</td></tr><tr><td>Mobile No</td><td>" + Input.Mobile + "</td></tr><tr><td>Address</td><td>" + Input.Address + "</td></tr><tr><td>State</td><td>" + Input.State + "</td></tr><tr><td>City</td><td>" + Input.City + "</td></tr><tr><td>Pincode</td><td>" + Input.Pincode + "</td></tr><tr><td>Geo Cordinates</td><td>" + Input.Latitude + "," + Input.Longitude + "</td></tr><tr><td>Email</td><td>" + Input.Email + "</td></tr><tr><td>Middleware Code</td><td>" + Input.Id + "</td></tr><tr><td>GST</td><td>" + Input.GST + "</td></tr></tbody></table><p>Regards,</p><p>Abhijeet</p>";
                    _emailSender.SendEmailAsync(
                      "mukund.bandre@gmail.com",
                      "New Registration Store",
                      messaage);
                    return RedirectToPage("/StoreLocatorConfirmation");
                }

              
                ModelState.AddModelError(string.Empty, "Failed to insert ");


             
            }

            return Page();

        }
    }
}
