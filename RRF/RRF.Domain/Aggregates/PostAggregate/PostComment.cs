using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        private PostComment()
        {                
        }

        public Guid CommentId { get; private set; }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastModifiedAt { get; private set; }

        public static PostComment CreatePostComment(Guid postId, Guid userProfileId, string text)
        {
            return new PostComment
            {
                PostId = postId,
                UserProfileId = userProfileId,
                Text = text,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow
            };
        }

        public void UpdateCommentText(string newText)
        {
            Text = newText;
            LastModifiedAt = DateTime.UtcNow;
        }
    }
}
