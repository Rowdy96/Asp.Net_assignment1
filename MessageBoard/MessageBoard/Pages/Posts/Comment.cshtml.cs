using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Core;
using MessageBoard.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MessageBoard.Pages.Posts
{
    public class CommentModel : PageModel
    {
       
       
        [BindProperty]
        public Post Post { get; set; }

   
        public IPostData postData { get; set; }
        public CommentModel(IPostData postData)
        {
            this.postData = postData;
        }

        public IActionResult OnGet(int? postId)
        {
            if(postId.HasValue)
             
            Post = postData.GetPostById(postId.Value);

            if (Post == null)
            {
                return RedirectToPage("./Post");
            }
            return Page();
        }
        public IActionResult OnPost(int postId)
        {
           
            var Postnew = postData.Addcomments(Post);
            postData.commit();
            return RedirectToPage("./Comment", new { postId = Postnew.Id });

        }

        public IActionResult OnPostCount(int postId)
        {
            Post = postData.GetPostById(postId);
            Post.Like = postData.CountLike(Post);
            postData.commit();
            return RedirectToPage("./Comment", new { postId = Post.Id });

        }

    }
}