using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CB8_TeamYBD_GroupProject_MVC.Models;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class CB8_TeamYBD_GroupProject_MVCContext : IdentityDbContext<CB8_TeamYBD_GroupProject_MVCUser>
    {
        public CB8_TeamYBD_GroupProject_MVCContext(DbContextOptions<CB8_TeamYBD_GroupProject_MVCContext> options)
            : base(options)
        {
        }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.Article> Articles { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.ArticleLike> ArticleLikes { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.Comment> Comments { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.Share> Shares { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.CommentLike> CommentLikes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.ArticlePurchase> ArticlePurchases { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.Follow> Follows { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.UserSubcription> UserSubcriptions { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.SubscriptionListing> SubscriptionListings { get; set; }
        public DbSet<CB8_TeamYBD_GroupProject_MVC.Models.CommentResponse> CommentResponses { get; set; }
    }
}
