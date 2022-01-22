using Holism.Blog.DataAccess;

namespace Holism.Blog.Business;

public class BlogPostBusiness : Business<BlogPost, BlogPost>
{
    protected override Repository<BlogPost> WriteRepository => Repository.BlogPost;

    protected override ReadRepository<BlogPost> ReadRepository => Repository.BlogPost;
}
