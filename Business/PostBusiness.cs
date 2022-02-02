namespace Blog;

public class PostBusiness : Business<Blog.Post, Blog.Post>
{
    public const string EntityType = "BlogPost";

    public const string PostImagesContainerName = "blogpostimages";

    protected override Repository<Blog.Post> WriteRepository => Blog.Repository.Post;

    protected override ReadRepository<Blog.Post> ReadRepository => Blog.Repository.Post;

    public Blog.Post ToggleCommentAcceptance(long id)
    {
        var post = Get(id);
        post.AcceptsComment = post.AcceptsComment == null ? true : !post.AcceptsComment;
        Update(post);
        return post;
    }

    protected override void ModifyItemBeforeReturning(Blog.Post item)
    {
        item.RelatedItems.TimeAgo = UniversalDateTime.Now.Subtract(item.UtcDate).Humanize();
        if (item.LastUpdateUtcDate.HasValue)
        {
            item.RelatedItems.LastUpdateTimeAgo = UniversalDateTime.Now.Subtract(item.LastUpdateUtcDate.Value).Humanize();
        }
        item.RelatedItems.StateKey = item.StateId.ToEnum<State>().ToString();
        item.RelatedItems.EntityType = EntityType;
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

    public Blog.Post ChangeImage(long postId, byte[] bytes)
    {
        var post = Get(postId);
        if (post.ImageGuid.HasValue)
        {
            Storage.DeleteImage(PostImagesContainerName, post.ImageGuid.Value);
        }
        var fullHdImage = ImageHelper.MakeImageThumbnail(Resolution.FullHd, null, bytes);
        post.ImageGuid = Guid.NewGuid();
        Storage.UploadImage(fullHdImage.GetBytes(), post.ImageGuid.Value, PostImagesContainerName);
        WriteRepository.Update(post);
        post = Get(postId);
        return post;
    }
}
