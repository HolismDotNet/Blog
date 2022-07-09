namespace Blog;

public class BlogPostController : Controller<Blog.PostView, Blog.Post>
{
    public override ReadBusiness<Blog.PostView> ReadBusiness => new Blog.PostBusiness();
    
    public override Business<Blog.PostView, Blog.Post> Business => new Blog.PostBusiness();

    [HttpPost]
    public Blog.PostView ChangeState(long id, long newEnumId)
    {
        var post = new Blog.PostBusiness().ChangeState(id, newEnumId);
        return post;
    }
}
