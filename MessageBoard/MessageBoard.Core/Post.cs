using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MessageBoard.Core
{
    public class Post
    {
        public int  Id { get; set; }
        [Required]
        public string Message { get; set; }
        public List<string> Comment;
    }
}
