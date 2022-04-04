namespace Blog;

public class PostContentBusiness : Business<Blog.PostContent, Blog.PostContent>
{
    protected override Read<Blog.PostContent> Read => Repository.PostContent;

    protected override Write<Blog.PostContent> Write => Repository.PostContent;

    public override Blog.PostContent Get(long id)
    {
        var postContent = Read.Get(id);
        if (postContent == null)
        {
            postContent = new PostContent();
            postContent.Id = id;
            postContent.Content = "[]";
            Create(postContent);
        }
        return postContent;
    }
}