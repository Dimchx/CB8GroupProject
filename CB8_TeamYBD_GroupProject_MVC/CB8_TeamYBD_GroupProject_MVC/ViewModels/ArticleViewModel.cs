using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using CB8_TeamYBD_GroupProject_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public CB8_TeamYBD_GroupProject_MVCUser Author { get; set; }
        [Required]
        public string Content { get; set; }
        public bool Paid { get; set; }
    }
}
