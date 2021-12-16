namespace Holism.Blog.Models;

public class PostHtml : IEntity
{
    public PostHtml()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Html { get; set; }

    public dynamic RelatedItems { get; set; }
}
