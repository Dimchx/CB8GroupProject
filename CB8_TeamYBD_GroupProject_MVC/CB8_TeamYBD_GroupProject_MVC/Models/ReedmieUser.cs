using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class ReedmieUser:IdentityUser
    {
        public virtual ICollection<Article> AuthoredArticles { get; set; }
        public virtual ICollection<Article> LikedArticles { get; set; }
        public virtual ICollection<Article> PurchasedArticles { get; set; }
        public virtual ICollection<ReedmieUser> Following { get; set; }
        public virtual ICollection<ReedmieUser> Followers { get; set; }
        public virtual ICollection<ReedmieUser> SubscribedTo { get; set; }
        public virtual ICollection<ReedmieUser> Subscribers { get; set; }

    }
}
