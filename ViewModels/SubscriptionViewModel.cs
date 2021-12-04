using ClassManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassManagement.ViewModels
{
    public class SubscriptionViewModel
    {
        public CourseRegistration CourseRegistration { get; set; }
        public List<Status> Status { get; set; }

    }
}