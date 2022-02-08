﻿namespace Blog;

public class PostBusiness : Business<Blog.PostView, Blog.Post>
{
    public const string EntityType = "BlogPost";

    public const string PostImagesContainerName = "blogpostimages";

    protected override Repository<Blog.Post> WriteRepository => Blog.Repository.Post;

    protected override ReadRepository<Blog.PostView> ReadRepository => Blog.Repository.PostView;

    public Blog.PostView ToggleCommentAcceptance(long id)
    {
        var post = WriteRepository.Get(id);
        post.AcceptsComment = post.AcceptsComment == null ? true : !post.AcceptsComment;
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
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(PostImagesContainerName, item.ImageGuid ?? Guid.Empty);
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

    public Blog.PostView ChangeImage(long postId, byte[] bytes)
    {
        var post = WriteRepository.Get(postId);
        if (post.ImageGuid.HasValue)
        {
            Storage.DeleteImage(PostImagesContainerName, post.ImageGuid.Value);
        }
        var fullHdImage = ImageHelper.MakeImageThumbnail(Resolution.FullHd, null, bytes);
        post.ImageGuid = Guid.NewGuid();
        Storage.UploadImage(fullHdImage.GetBytes(), post.ImageGuid.Value, PostImagesContainerName);
        WriteRepository.Update(post);
        return Get(postId);
    }
}
