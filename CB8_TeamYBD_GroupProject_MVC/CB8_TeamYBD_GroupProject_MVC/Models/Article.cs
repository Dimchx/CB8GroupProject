﻿using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public CB8_TeamYBD_GroupProject_MVCUser Author { get; set; }
        [Required]
        public string Content { get; set; }
        public bool Paid { get; set; }
        public DateTime PostDateTime { get; set; }

        public static explicit operator Article(ArticleViewModel v)
        {
            return new Article() { Title = v.Title, Author = v.Author, Content = v.Content, Paid = v.Paid };
        }
    }
}
