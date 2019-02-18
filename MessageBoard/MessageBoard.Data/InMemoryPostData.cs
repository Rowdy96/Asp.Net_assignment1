using MessageBoard.Core;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Data
{
    public class InMemoryPostData : IPostData
    {
        List<Post> Posts;
        public InMemoryPostData()
        {
            Posts = new List<Post>(){};
        }

        public Post AddPost(Post newpost)
        {
            Posts.Add(newpost);
            newpost.Id = Posts.Max(p => p.Id) + 1;
            return newpost;
        }

        public Post Addcomments(Post newComment)
        {
            var messages = Posts.SingleOrDefault(r => r.Id == newComment.Id);
            messages.c = messages.c + " " + newComment.c;
            return messages;
        }

        public int commit()
        {
            return 0;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return from p in Posts
                   orderby p.Id
                   select p;
        }

        public Post GetPostById(int? Id)
        {
            return Posts.SingleOrDefault(r => r.Id == Id);
        }

        public int CountLike(Post CountPost)
        {
            var Post = Posts.SingleOrDefault(r => r.Id == CountPost.Id);
            Post.Like = Post.Like +1;
            return Post.Like;
        }

       
    }
}
