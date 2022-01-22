using Holism.Blog.DataAccess;

namespace Holism.Blog.Business;

public class BlogPostBusiness : Business<BlogPost, BlogPost>
{
    protected override Repository<BlogPost> WriteRepository => Repository.BlogPost;

    protected override ReadRepository<BlogPost> ReadRepository => Repository.BlogPost;

    protected override void ModifyItemBeforeReturning(BlogPost item)
    {
        item.RelatedItems.TimeAgo = UniversalDateTime.Now.Subtract(item.UtcDate).Humanize();
        if (item.LastUpdateUtcDate.HasValue)
        {
            item.RelatedItems.LastUpdateTimeAgo = UniversalDateTime.Now.Subtract(item.LastUpdateUtcDate).Humanize();
        }
        item.RelatedItems.PostStateKey = item.PostStateId.CastTo<PostState>().ToString();
        base.ModifyItemBeforeReturning(item);
    }

    protected override void PreCreation(BlogPost model)
    {
        model.UtcDate = UniversalDateTime.Now;
        model.PostStateId = (int)PostState.Draft;
        base.PreCreation(model);
    }

    protected override void PreUpdate(BlogPost model)
    {
        model.LastUpdateUtcDate = UniversalDateTime.Now;
        base.PreUpdate(model);
    }
}
