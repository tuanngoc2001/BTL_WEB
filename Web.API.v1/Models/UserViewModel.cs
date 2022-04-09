using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class UserViewModel
    {
        public List<UserModel> Users { get; set; }
        public SelectList DSUser { get; set; }
        public string User { get; set; }
        public string searchString { get; set; }
    }
}
