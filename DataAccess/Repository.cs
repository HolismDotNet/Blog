namespace Holism.Blog.DataAccess;

public class Repository
{
    public static Repository<PostHtml> PostHtml
    {
        get
        {
            return new Repository<PostHtml>(new BlogContext());
        }
    }

    public static Repository<Post> Post
    {
        get
        {
            return new Repository<Post>(new BlogContext());
        }
    }


}
