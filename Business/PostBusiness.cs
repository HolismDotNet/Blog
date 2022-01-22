using Holism.Blog.DataAccess;

namespace Holism.Blog.Business;

public class PostBusiness : Business<Post, Post>
{
    protected override Repository<Post> WriteRepository => Repository.Post;

    protected override ReadRepository<Post> ReadRepository => Repository.Post;
}
