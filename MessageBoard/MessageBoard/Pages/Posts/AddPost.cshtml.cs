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
    public class AddPostModel : PageModel
    {
        public IPostData postData { get; set; }
        [BindProperty]
        public Post Post { get; set; }

        public AddPostModel(IPostData postData)
        {
            this.postData = postData;
        }
        public IActionResult OnGet(int? postId)
        {
            if (postId.HasValue) {
                Post = postData.GetPostById(postId);
            }
            else
            {
                Post = new Post();
                
            }
           
            if(Post == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
           
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid) {

                postData.AddPost(Post);
                postData.commit();
                return RedirectToPage("./Comment", new { postId = Post.Id });
            }
            return Page();
        }
    }
}