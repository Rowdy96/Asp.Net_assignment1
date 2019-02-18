using MessageBoard.Core;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Data
{
    public interface IPostData
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int? Id);
        Post AddPost(Post newpost);
        Post Addcomments(Post newComment);
        int CountLike(Post post);
        int commit();
      
    }
}
