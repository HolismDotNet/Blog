namespace Blog;

public class BlogPostController : Controller<Blog.Post, Blog.Post>
{
    public override ReadBusiness<Blog.Post> ReadBusiness => new Blog.PostBusiness();
    
    public override Business<Blog.Post, Blog.Post> Business => new Blog.PostBusiness();
}
