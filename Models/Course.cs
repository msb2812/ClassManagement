using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassManagement.Models
{
    public class Course
    {

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Course Name is required")]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course Fees is required")]
        public decimal Fees { get; set; }

        [Required(ErrorMessage = "Course Duration is required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Course Capacity is required")]
        [Display(Name = "Student's Seating Capacity")]
        public int Capacity { get; set; }
    }
}