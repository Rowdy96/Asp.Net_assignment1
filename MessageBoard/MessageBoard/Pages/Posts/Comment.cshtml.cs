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



        public Post Post { get; set; }
        [BindProperty]
        private string comment { get; set; }

        public IPostData postData { get; set; }
        public string Comment { get => comment; set => comment = value; }

        public CommentModel(IPostData postData)
        {
            this.postData = postData;
        }

        public IActionResult OnGet(int postId)
        {
            Post = postData.GetPostById(postId);
            return Page();
        }

        public IActionResult OnPost(int postId)
        {

            Post = postData.GetPostById(postId);
            postData.Addcomments(Post);
            postData.commit();
            return RedirectToPage("./Post");

        }

    }
}