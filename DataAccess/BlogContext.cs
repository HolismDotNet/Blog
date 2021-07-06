using Holism.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Holism.Blog.Models;

namespace Holism.Blog.DataAccess
{
    //[DbConfigurationType(typeof(EntityFrameworkConfiguration))]
    public class PostDbContext : DatabaseContext
    {
        public override string ConnectionStringName => "Blog";

        public DbSet<Post> Posts {get; set;}
        public DbSet<Voice> Voices {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().Ignore(i => i.RelatedItems);
            modelBuilder.Entity<Voice>().Ignore(i => i.RelatedItems);
			// modelBuilder.Entity<Post>().Property(i => i.Date).HasComputedColumnSql("([dbo].[ToPersianDateTime]([Date]))");
            base.OnModelCreating(modelBuilder);
        }
    }
}
