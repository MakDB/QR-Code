using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QR_Material_Scanner.Models;

namespace QR_Material_Scanner.Pages
{
    public class StoreCodeSearchModel : PageModel
    {
        private readonly IRepository _repository;
        //private readonly IMailService _emailSender;

        public StoreCodeSearchModel(IRepository repository)
        {
            _repository = repository;
           // _emailSender = emailSender;
        }
        [BindProperty(SupportsGet = true)]
        public string Code { get; set; }
        public Middleware_Retailer retailer { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(Code))
            {
                return;
            }
            retailer = _repository.GetRetailer(Convert.ToInt32(Code));

        }
    }
}
