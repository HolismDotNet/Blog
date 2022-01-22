namespace Holism.Blog.DataAccess;

public class BlogContext : DatabaseContext
{
    public override string ConnectionStringName => "Blog";

    public DbSet<BlogPostContent> BlogPostContents { get; set; }

    public DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
