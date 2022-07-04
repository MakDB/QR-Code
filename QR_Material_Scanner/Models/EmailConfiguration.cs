using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
    public class EmailConfiguration
    {
            public string From { get; set; }
            public string SmtpServer { get; set; }
            public int Port { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
      
    }
    public class EmailID
    {
        [Key]
        public string Email { get; set; }
    

    }
}
