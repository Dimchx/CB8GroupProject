using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class SubscriptionListing
    {
        public SubscriptionListing(CB8_TeamYBD_GroupProject_MVCUser user)
        {
            User = user;
        }

        public int Id { get; set; }
        public CB8_TeamYBD_GroupProject_MVCUser User { get; set; }
        public double MonthlyPrice { get; set; }
        public double TrimesterPrice { get; set; }
        public double SemesterPrice { get; set; }
        public double YearlyPrice { get; set; }
    }
}
