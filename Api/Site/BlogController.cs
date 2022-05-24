namespace Blog;

public class BlogController : HolismController
{
    [HttpGet]
    public object Data()
    {
        dynamic data = new ExpandoObject();
        data.Posts = new Blog.PostBusiness().GetList(ListParameters.Create());
        data.Categories = new HierarchyBusiness().GetTree(new Blog.PostBusiness().EntityType);
        data.Tags = new TagBusiness().GetTags(new Blog.PostBusiness().EntityType);
        data.Seo = new ParametersObject();
        return data;
    }
}