using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        private PostInteraction()
        {
        }
        public Guid InteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime LastModifiedAt { get; private set; }

        public static PostInteraction CreatePostInteraction(Guid postId, InteractionType interactionType)
        {
            return new PostInteraction
            {
                PostId = postId,
                InteractionType = interactionType,
                CreateAt = DateTime.Now,
                LastModifiedAt = DateTime.Now
            };
        }

        public void UpdatePostInteraction(InteractionType type)
        {
            InteractionType = type;
            LastModifiedAt = DateTime.UtcNow;
        }


    }
}
