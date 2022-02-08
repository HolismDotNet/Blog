namespace Blog;

public class PostView : IEntity, IGuid, ISlug
{
    public PostView()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Title { get; set; }

    public string Slug { get; set; }

    public string Summary { get; set; }

    public int? TimeToRead { get; set; }

    public Guid? ImageGuid { get; set; }

    public bool? AcceptsComment { get; set; }

    public DateTime UtcDate { get; set; }

    public DateTime? LastUpdateUtcDate { get; set; }

    public long StateId { get; set; }

    public string TagsCsv { get; set; }

    public dynamic RelatedItems { get; set; }
}
