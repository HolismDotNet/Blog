using Holism.Blog.DataAccess;

namespace Holism.Blog.Business;

public class BlogPostBusiness : Business<BlogPost, BlogPost>
{
    protected override Repository<BlogPost> WriteRepository => Repository.BlogPost;

    protected override ReadRepository<BlogPost> ReadRepository => Repository.BlogPost;

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
