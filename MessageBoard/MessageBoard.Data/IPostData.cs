using MessageBoard.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MessageBoard.Data
{
    public interface IPostData
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int? Id);
        Post AddPost(Post newpost);
       // List<string> AddComment(string newComment);
        int commit();
        
    }

    public class InMemoryPostData : IPostData
    {
        List<Post> Posts;
        public InMemoryPostData()
        {
            Posts = new List<Post>()
            {
                new Post { Id= 1,Message="this is a post 1.Add new Message", /*Comment= new List<string>(){ "Comment1","Comment2"* } */},
                //  new Post { Id= 2,Message="this is a post 2.Add new Message"},
                //   new Post { Id= 3,Message="this is a post 3.Add new Message"},
            };
        }

        //public List<string> AddComment(string newComment)
        //{
            
        //    return ;
        //}

        public Post AddPost(Post newpost)
        {
            Posts.Add(newpost);
            newpost.Id = Posts.Max(p => p.Id) + 1;
            return newpost;
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
    }
}
