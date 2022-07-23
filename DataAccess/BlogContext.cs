namespace Blog;

public class BlogContext : DatabaseContext
{
    public override string ConnectionStringName => "Blog";

    public DbSet<Blog.Author> Authors { get; set; }

    public DbSet<Blog.PostContent> PostContents { get; set; }

    public DbSet<Blog.Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
