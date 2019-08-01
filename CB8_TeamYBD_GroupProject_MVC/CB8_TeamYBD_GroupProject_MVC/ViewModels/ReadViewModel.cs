using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using CB8_TeamYBD_GroupProject_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.ViewModels
{
    public class ReadViewModel
    {
        public Article Article {get;set;}
        public DateTime ArticlePostDateTime { get; set; }
        public CB8_TeamYBD_GroupProject_MVCUser Author { get; set; }
        public List<ArticleLike> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
