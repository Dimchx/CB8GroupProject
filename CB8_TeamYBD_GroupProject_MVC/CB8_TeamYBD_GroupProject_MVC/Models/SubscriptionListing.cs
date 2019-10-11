using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;
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
        public int Id { get; set; }
        [Required]
        public CB8_TeamYBD_GroupProject_MVCUser User { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        public int DayDuration { get; set; }
        public int MonthDuration { get; set; }

        public static explicit operator SubscriptionListing(SubscriptionListingViewModel v)
        {
            return new SubscriptionListing() { User = v.User, Title = v.Title, Price = v.Price, DayDuration = v.DayDuration, MonthDuration = v.MonthDuration };
        }
    }
}
