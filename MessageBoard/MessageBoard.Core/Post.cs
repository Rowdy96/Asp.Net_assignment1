using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace MessageBoard.Core
{
    public class Post
    {
        public int  Id { get; set; }
        [Required]
        public string Message { get; set; }
        public string c { get; set; }
        public int Like { get; set; }
    }
}
