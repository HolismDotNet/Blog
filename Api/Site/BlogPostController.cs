namespace Blog;

public class BlogPostController : ReadController<Blog.Post>
{
    public override ReadBusiness<Blog.Post> ReadBusiness => new Blog.PostBusiness();
}