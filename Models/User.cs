using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassManagement.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Full Nme")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "User Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Display(Name = "Course")]                  // Foreign Key
        //public int CourseId { get; set; }

        //public Course Course { get; set; }

        public int RoleId { get; set; }             // Foreign Key

        public Role Role { get; set; }

    }
}