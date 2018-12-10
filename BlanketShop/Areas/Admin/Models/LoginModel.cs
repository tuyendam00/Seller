using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlanketShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập Username ")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập Password ")]
        public string PassWord { set; get; }
        public bool RememberMe { set; get; }
    }
}