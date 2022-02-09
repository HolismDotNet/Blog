namespace Blog;

public class BlogPostController : ReadController<Blog.PostView>
{
    public override ReadBusiness<Blog.PostView> ReadBusiness => new Blog.PostBusiness();
}