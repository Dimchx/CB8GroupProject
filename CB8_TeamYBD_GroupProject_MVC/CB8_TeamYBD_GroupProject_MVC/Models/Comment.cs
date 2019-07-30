using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public CB8_TeamYBD_GroupProject_MVCUser User { get; set; }
        public Article Article { get; set; }
        public string Content { get; set; }
    }
}
