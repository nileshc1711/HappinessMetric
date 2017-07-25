using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessMetric.Models
{
    public class UserViewModel
    {
        public string LanID { get; set; }
        public string UserName
        {
            get
            {
                return LanID.Substring(LanID.IndexOf('\\') + 1);
            }
        }
    }
}