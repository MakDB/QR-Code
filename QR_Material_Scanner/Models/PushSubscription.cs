using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
    [Table("mst_PushSubscription")]
    public class PushSubscription
    {

        [Key]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Endpoint { get; set; }

        public double? ExpirationTime { get; set; }
        [Required]
        public string P256Dh { get; set; }
        [Required]
        public string Auth { get; set; }

        [Required]
        public string Plant { get; set; }
      
    }


    public class Return_PushSubscription
    {
        [Key]
        public string UserName { get; set; }
        public string Status_Code { get; set; }
        public string Status { get; set; }


        
    }
}
