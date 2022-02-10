namespace Blog;

public class BlogPostContentController : Controller<Blog.PostContent, Blog.PostContent>
{
    public override ReadBusiness<Blog.PostContent> ReadBusiness => new Blog.PostContentBusiness();
    
    public override Business<Blog.PostContent, Blog.PostContent> Business => new Blog.PostContentBusiness();
}