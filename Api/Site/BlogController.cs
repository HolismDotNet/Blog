namespace Blog;

public class BlogController : HolismController
{
    [BindProperty(SupportsGet=true)]
    public int? PageSize { get; set; }

    [BindProperty(SupportsGet=true)]
    public int? PageNumber { get; set; }

    [BindProperty(SupportsGet=true)]
    public string Hierarchy { get; set; }

    [BindProperty(SupportsGet=true)]
    public string Tag { get; set; }

    public string CanonicalUrl { get; set; }

    [HttpGet]
    public object Data()
    {
        dynamic data = new ExpandoObject();
        data.Posts = GetPosts();
        data.Hierarchies = GetHierarchies();
        data.Tags = GetTags();
        data.Seo = GetSeo();
        return data;
    }

    public ListResult<Blog.PostView> GetPosts()
    {
        var postsListParameters = ListParameters.Create();
        if (PageSize.HasValue)
        {
            postsListParameters.PageSize = PageSize.Value;
        }
        if (PageNumber.HasValue)
        {
            postsListParameters.PageNumber = PageNumber.Value;
        }
        var posts = new Blog.PostBusiness().GetList(postsListParameters);
        return posts;
    }

    public List<HierarchyView> GetHierarchies()
    {
        var hierarchies = new HierarchyBusiness().GetTree(new Blog.PostBusiness().EntityType);
        return hierarchies;
    }

    public List<Tag> GetTags()
    {
        var tags = new TagBusiness().GetTags(new Blog.PostBusiness().EntityType);
        return tags;
    }

    public object GetSeo()
    {
        var seo = new ParametersObject();
        CanonicalUrl = "/blog";
        return seo;
    }
}