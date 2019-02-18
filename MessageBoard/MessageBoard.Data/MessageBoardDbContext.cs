using MessageBoard.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Data
{
    public class MessageBoardDbContext:DbContext
    {

        public DbSet<Post> Post { get; set; }
        public MessageBoardDbContext(DbContextOptions<MessageBoardDbContext>options):base(options)
        {

        }
       

    }
}
