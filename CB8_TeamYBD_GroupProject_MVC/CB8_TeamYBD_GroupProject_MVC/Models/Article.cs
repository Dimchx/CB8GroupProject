using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public IdentityUser Author { get; set; }
        [Required]
        public string Content { get; set; }
        public bool Paid { get; set; }
        public ICollection<IdentityUser> PurchasedBy { get; set; }
        public ICollection<IdentityUser> LikedBy { get; set; }
    }
}
