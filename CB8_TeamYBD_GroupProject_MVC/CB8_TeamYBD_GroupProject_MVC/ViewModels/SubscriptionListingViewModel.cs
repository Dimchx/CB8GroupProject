using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.ViewModels
{
    public class SubscriptionListingViewModel
    {
        public int Id { get; set; }
        
        public CB8_TeamYBD_GroupProject_MVCUser User { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        public int DayDuration { get; set; }
        public int MonthDuration { get; set; }
    }
}
