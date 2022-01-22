namespace Holism.Blog.Models;

public class BlogPostContent : IEntity
{
    public BlogPostContent()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Content { get; set; }

    public dynamic RelatedItems { get; set; }
}
