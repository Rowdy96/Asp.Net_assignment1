using MessageBoard.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Data
{
    public class SqlPostData : IPostData
    {
        private readonly MessageBoardDbContext db;

        public SqlPostData(MessageBoardDbContext db)
        {
            this.db = db;
        }

        public Post Addcomments(Post updatedPost)
        {
           // var entity = db.Post.Attach(updatedPost);
            //entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedPost;
        }

        public Post AddPost(Post newpost)
        {
            db.Add(newpost);
            return newpost;
            
        }

        public int commit()
        {
            return db.SaveChanges();
        }

        public int CountLike(Post post)
        {
            var Post = db.Post.SingleOrDefault(r => r.Id == post.Id);
            Post.Like = Post.Like + 1;
            return Post.Like;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            var query =  from p in db.Post select p;
            return query;
        }

        public Post GetPostById(int? Id)
        {
            return db.Post.Find(Id);
        }
    }
}
