using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Models
{
    public class CommentResponseLike
    {
        public int Id { get; set; }
        public CB8_TeamYBD_GroupProject_MVCUser User { get; set; }
        public CommentResponse Comment { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
}
