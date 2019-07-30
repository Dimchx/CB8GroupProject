using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class UserSubcription
    {
        public int Id { get; set; }
        public CB8_TeamYBD_GroupProject_MVCUser Author { get; set; }
        public CB8_TeamYBD_GroupProject_MVCUser Subscriber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
    }
}
