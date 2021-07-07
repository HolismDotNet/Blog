using Holism.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Holism.Blog.Models;

namespace Holism.Blog.DataAccess
{
    public class BlogContext : DatabaseContext
    {
        public override string ConnectionStringName => "Blog";

        public DbSet<Post> Posts {get; set;}
        public DbSet<Voice> Voices {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().Ignore(i => i.RelatedItems);
            modelBuilder.Entity<Voice>().Ignore(i => i.RelatedItems);
            base.OnModelCreating(modelBuilder);
        }
    }
}
