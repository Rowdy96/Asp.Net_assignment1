using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Core;
using MessageBoard.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessageBoard.Pages.Posts
{
    public class CommentModel : PageModel
    {
        //public List<string> Comment;
        public CommentModel(IPostData postData)
        {
            this.postData = postData;
        }
        public Post Post { get; set; }
        public IPostData postData { get; set; }

        public IActionResult OnGet(int postId)
        {
            Post = postData.GetPostById(postId);
            if (Post == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int postId)
        {
            if (ModelState.IsValid)
            {


                
                return RedirectToPage("./Comment", new { postId = Post.Id });
            }
            return Page();
        }
    }
}