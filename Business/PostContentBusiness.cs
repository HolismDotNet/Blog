namespace Blog;

public class PostContentBusiness : Business<Blog.PostContent, Blog.PostContent>
{
    protected override Read<Blog.PostContent> Read => Repository.PostContent;

    protected override Write<Blog.PostContent> Write => Repository.PostContent;
}