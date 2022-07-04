using Microsoft.AspNetCore.Mvc;
using QR_Material_Scanner.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
    public class Retailer
    {

        [Key]
        public string Id { get; set; } =
        Convert.ToString(Guid.NewGuid());

        [Required]
        [Display(Name = "Business Name")]
        public string Business_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
      
        [RegularExpression(@"^([1-9]{1}[0-9]{5})$", ErrorMessage = "Invalid pincode Number.")]
        [Display(Name = "Pincode")]
        public string Pincode { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Latitude {0} is required. Allow Share your location")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Longitude {0} is required. Allow Share your location")]
        public string Longitude { get; set; }

        [Required]
        [EmailAddress]
       
        [ValidEmailDomain(allowedDomain: "gmail.com",
             ErrorMessage = "Email domain must be gmail.com")]
        public string Email { get; set; }
        
        [Required]
        public string GST { get; set; }

        [Display(Name = "Middleware ID")]
        public string Code { get; set; }
    }


    public class Retailer_Status
    {
        [Key]
        public string Status_Code { get; set; }
        public string Status { get; set; }
    }




    public class Middleware_Retailer
    {

        [Key]
        public int Id { get; set; } 

        [Required]
        [Display(Name = "Business Name")]
        public string Business_Name { get; set; }
        [Required]
        public string Address { get; set; } = null;
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        
        [Display(Name = "Pincode")]
        [Required]
        [RegularExpression(@"^([1-9]{1}[0-9]{5})$", ErrorMessage = "Invalid pincode Number.")]
        public string Pincode { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Latitude {0} is required. Allow Share your location")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Longitude {0} is required. Allow Share your location")]
        public string Longitude { get; set; }

       
        [EmailAddress]
        //[ValidEmailDomain(allowedDomain: "gmail.com",
        //     ErrorMessage = "Email domain must be gmail.com")]
        public string Email { get; set; }

   
        [Required(ErrorMessage = "GST Number required length is 15")]
        [StringLength(15, MinimumLength = 15)]
        public string GST { get; set; }

        public string Branch { get; set; }

 
        public string Modified_By { get; set; }
    }
}
