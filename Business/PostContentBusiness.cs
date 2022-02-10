namespace Blog;

public class PostContentBusiness : Business<Blog.PostContent, Blog.PostContent>
{
    protected override ReadRepository<Blog.PostContent> ReadRepository => Repository.PostContent;

    protected override Repository<Blog.PostContent> WriteRepository => Repository.PostContent;
}