using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplicaition.Models
{
    public class LoginModel
    {
        public string emailid { get; set; }
        public string password { get; set; }
    }

    public class LoginResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }
}