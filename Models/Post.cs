namespace Holism.Blog.Models;

public class Post : IGuidEntity
{
    public Post()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Title { get; set; }

    public string Summary { get; set; }

    public int? TimeToRead { get; set; }

    public DateTime UtcDate { get; set; }

    public long PostStateId { get; set; }

    public dynamic RelatedItems { get; set; }
}
