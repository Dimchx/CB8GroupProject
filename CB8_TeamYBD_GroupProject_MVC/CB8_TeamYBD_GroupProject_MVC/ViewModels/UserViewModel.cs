using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using CB8_TeamYBD_GroupProject_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.ViewModels
{
    public class UserViewModel
    {
        public CB8_TeamYBD_GroupProject_MVCUser User { get; set; }
        public List<Article> Articles { get; set; }
        public List<SubscriptionListing> listings { get; set; }
    }
}
