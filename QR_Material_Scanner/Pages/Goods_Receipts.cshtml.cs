using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QR_Material_Scanner.Models;

namespace QR_Material_Scanner.Pages
{
    public class Goods_ReceiptsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public Goods_ReceiptsModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
        }
        //public async Task<IActionResult> OnGetAsync()

        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    try
        //    {

        //        // Verification.  
        //        if (user == null)
        //        {
        //            return RedirectToPage("./login");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Info  
        //        Console.Write(ex);
        //    }

        //    // Info.  
        //    return this.Page();
        //}
    }
}
