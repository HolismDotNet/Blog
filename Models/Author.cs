namespace Blog;

public class Author : IEntity, IGuid, ISlug
{
    public Author()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public Guid ContactGuid { get; set; }

    public bool? IsDefault { get; set; }

    public string Slug { get; set; }

    public dynamic RelatedItems { get; set; }
}
