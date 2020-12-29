using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
   public class clsLoginResponse
    {
        public string UserId { get; set; }
        public bool Status { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
    }
}
