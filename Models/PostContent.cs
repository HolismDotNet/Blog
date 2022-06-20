namespace Blog;

public class PostContent : IEntity, IClob
{
    public PostContent()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Content { get; set; }

    public dynamic RelatedItems { get; set; }
}
