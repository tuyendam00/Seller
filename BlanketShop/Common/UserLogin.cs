using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlanketShop.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
    }
}