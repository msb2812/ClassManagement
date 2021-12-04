using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassManagement.Models
{
    public class CourseRegistration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}