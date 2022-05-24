namespace Blog;

public class BlogController : HolismController
{
    [BindProperty(SupportsGet=true)]
    public int? PostsCount { get; set; }

    [HttpGet]
    public object Data()
    {
        dynamic data = new ExpandoObject();
        var postsListParameters = ListParameters.Create();
        if (PostsCount.HasValue)
        {
            postsListParameters.PageSize = PostsCount.Value;
        }
        data.Posts = new Blog.PostBusiness().GetList(postsListParameters);
        data.Categories = new HierarchyBusiness().GetTree(new Blog.PostBusiness().EntityType);
        data.Tags = new TagBusiness().GetTags(new Blog.PostBusiness().EntityType);
        data.Seo = new ParametersObject();
        return data;
    }
}