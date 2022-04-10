using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Data;

namespace Web_API_v1.Models
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public SelectList DSUser { get; set; }
        public string User { get; set; }
        public string searchString { get; set; }
    }
}
