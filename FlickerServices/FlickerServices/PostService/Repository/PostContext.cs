using Microsoft.EntityFrameworkCore;
using PostService.Entities;
using System.Collections.Generic;

namespace PostService.Repository
{
    public class PostContext:DbContext
    {
        public PostContext() { }
        public PostContext(DbContextOptions<PostContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
    }
}
