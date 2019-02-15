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
    public class PostModel : PageModel
    {
        private readonly IPostData postData;
        public IEnumerable<Post> Posts { get; set; }
        public PostModel(IPostData postData)
        {
            this.postData = postData;
        }

        public void OnGet()
        {
            Posts = postData.GetAllPosts();
        }
    }
}