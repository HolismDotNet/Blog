namespace Blog;

public class BlogController : HolismController
{
    [HttpGet]
    public object Data()
    {
        dynamic data = new ExpandoObject();
        data.Posts = new Blog.PostBusiness().GetList(ListParameters.Create());
        return data;
    }
}