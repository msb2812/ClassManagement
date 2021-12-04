using ClassManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassManagement.ViewModels
{
    public class UserFormViewModel
    {
        public User User { get; set; }
        public List<Role> Role { get; set; }

    }
}