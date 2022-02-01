namespace Blog;

public class BlogStateController : EnumController<Blog.State>
{
    public override EnumBusiness<Blog.State> EnumBusiness => new Blog.StateBusiness();
}