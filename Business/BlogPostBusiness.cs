namespace Blog;

public class PostBusiness : Business<Blog.Post, Blog.Post>
{
    protected override Repository<Blog.Post> WriteRepository => Blog.Repository.Post;

    protected override ReadRepository<Blog.Post> ReadRepository => Blog.Repository.Post;

    protected override void ModifyItemBeforeReturning(Blog.Post item)
    {
        item.RelatedItems.TimeAgo = UniversalDateTime.Now.Subtract(item.UtcDate).Humanize();
        if (item.LastUpdateUtcDate.HasValue)
        {
            item.RelatedItems.LastUpdateTimeAgo = UniversalDateTime.Now.Subtract(item.LastUpdateUtcDate.Value).Humanize();
        }
        item.RelatedItems.StateKey = item.StateId.CastTo<State>().ToString();
        base.ModifyItemBeforeReturning(item);
    }

    protected override void PreCreation(Blog.Post model)
    {
        model.UtcDate = UniversalDateTime.Now;
        model.StateId = (int)Blog.State.Draft;
        base.PreCreation(model);
    }

    protected override void PreUpdate(Blog.Post model)
    {
        model.LastUpdateUtcDate = UniversalDateTime.Now;
        base.PreUpdate(model);
    }
}
