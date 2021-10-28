using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{

    public class CommentList
    {
        public List<Comment> comment { get; set; }
    }

    public class Comment
    {
        public string CommentID { get; set; }
        public string CommentText { get; set; }
        public string Rating { get; set; }
        public string ArticulId { get; set; }
        public string UserId { get; set; }
        public string UserLogin { get; set; }

        public Comment(string CommentID, string CommentText, string Rating, string ArticulId, string UserId, string UserLogin)
        {
            this.CommentID = CommentID;
            this.CommentText = CommentText;
            this.Rating = Rating;
            this.ArticulId = ArticulId;
            this.UserId = UserId;
            this.UserLogin = UserLogin;
        }
    }

}
