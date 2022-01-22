namespace Holism.Blog.AdminApi;

public class BlogPostController : Controller<BlogPost, BlogPost>
{
    public override ReadBusiness<BlogPost> ReadBusiness => new BlogPostBusiness();
    
    public override Business<BlogPost, BlogPost> Business => new BlogPostBusiness();
}
