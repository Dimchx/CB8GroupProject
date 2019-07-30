using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CB8_TeamYBD_GroupProject_MVCUser class
    public class CB8_TeamYBD_GroupProject_MVCUser : IdentityUser
    {
        public bool Premium { get; set; }
    }
}
