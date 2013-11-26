using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Testy1.Models {
    public class BlogContext : DbContext {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
