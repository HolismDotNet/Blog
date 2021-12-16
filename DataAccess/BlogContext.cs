namespace Holism.Blog.DataAccess;

public class BlogContext : DatabaseContext
{
    public override string ConnectionStringName => "Blog";

    public DbSet<PostHtml> PostHtmls { get; set; }

    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
