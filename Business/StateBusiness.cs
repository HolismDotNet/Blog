namespace Blog;

public class StateBusiness : EnumBusiness<Blog.State>
{
    public override string ConnectionString =>
        Blog.Repository.Post.ConnectionString;
}
