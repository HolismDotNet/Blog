namespace Blog;

public class BlogController : HolismController
{
    [BindProperty(SupportsGet=true)]
    public int? PageSize { get; set; }

    [BindProperty(SupportsGet=true)]
    public int? PageNumber { get; set; }

    [BindProperty(SupportsGet=true)]
    public string Hierarchy { get; set; }

    public HierarchyView DatabaseHierarchy { get; set; }

    [BindProperty(SupportsGet=true)]
    public string Tag { get; set; }

    public Tag DatabaseTag { get; set; }

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
        if (Hierarchy.IsSomething())
        {
            DatabaseHierarchy = new HierarchyBusiness().GetBySlug(Hierarchy);
        }
        return hierarchies;
    }

    public List<Tag> GetTags()
    {
        var tags = new TagBusiness().GetTags(new Blog.PostBusiness().EntityType);
        if (Tag.IsSomething())
        {
            DatabaseTag = new TagBusiness().GetBySlug(Tag);
        }
        return tags;
    }

    public object GetSeo()
    {
        var seo = new PathParameterBusiness().Get(Request.GetEncodedPathAndQuery()).CastTo<ParametersObject>();
        CanonicalUrl = "/blog";
        if (seo != null)
        {
            return seo;
        }
        if (DatabaseHierarchy != null)
        {
            seo = new EntityParameterBusiness().Get(new HierarchyBusiness().EntityType, DatabaseHierarchy.Guid).CastTo<ParametersObject>();
            if (seo == null)
            {
                seo = new ParametersObject();
                seo.PageTitle = DatabaseHierarchy.Title;
                seo.PageDescription = DatabaseHierarchy.Description;
            }
        }
        else if (DatabaseTag != null)
        {
            seo = new EntityParameterBusiness().Get(new TagBusiness().EntityType, DatabaseTag.Guid).CastTo<ParametersObject>();
            if (seo == null)
            {
                seo = new ParametersObject();
                seo.PageTitle = DatabaseTag.Name;
                seo.PageDescription = DatabaseTag.Description;
            }
        }
        if (seo == null)
        {
            seo = new QueryParameterBusiness().Get(new QueryParameterBusiness().GetSortedQuery(Request.Query)).CastTo<ParametersObject>();
        }
        if (seo == null)
        {
            seo = new ParametersObject();
            seo.PageTitle = "Blog";
        }
        return seo;
    }
}