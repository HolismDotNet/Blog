namespace Blog;

public class PostBusiness : Business<Blog.PostView, Blog.Post>
{
    public override string EntityType => "BlogPost";

    protected override Write<Blog.Post> Write => Blog.Repository.Post;

    protected override Read<Blog.PostView> Read => Blog.Repository.PostView;

    protected override Func<Sort> DefaultSort => () => new Sort
    {
        Property = nameof(Blog.PostView.LastUpdateUtcDate),
        Direction = SortDirection.Descending
    };

    public Blog.PostView ChangeState(long id, long newStateId)
    {
        var post = Write.Get(id);
        if (post.StateId == newStateId)
        {
            return Get(post.Id);
        }
        newStateId.Ensure().CanBeCastTo<Blog.State>();
        post.StateId = newStateId;
        Update(post);
        return Get(post.Id);
    }

    protected override void ModifyItemBeforeReturning(Blog.PostView item)
    {
        item.RelatedItems.TimeAgo = UniversalDateTime.Now.Subtract(item.UtcDate).Humanize();
        if (item.LastUpdateUtcDate.HasValue)
        {
            item.RelatedItems.LastUpdateTimeAgo = UniversalDateTime.Now.Subtract(item.LastUpdateUtcDate.Value).Humanize();
        }
        item.RelatedItems.StateKey = item.StateId.ToEnum<State>().ToString();
        item.RelatedItems.EntityType = EntityType;
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid ?? Guid.Empty);
        base.ModifyItemBeforeReturning(item);
    }

    protected override void PreCreation(Blog.Post model)
    {
        model.UtcDate = UniversalDateTime.Now;
        model.LastUpdateUtcDate = model.UtcDate;
        model.StateId = (int)Blog.State.Draft;
        base.PreCreation(model);
    }

    protected override void PreUpdate(Blog.Post model)
    {
        model.LastUpdateUtcDate = UniversalDateTime.Now;
        base.PreUpdate(model);
    }
}
