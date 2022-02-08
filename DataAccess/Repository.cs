namespace Blog;

public class Repository
{
    public static Repository<Blog.PostContent> PostContent
    {
        get
        {
            return new Repository<Blog.PostContent>(new BlogContext());
        }
    }

    public static Repository<Blog.Post> Post
    {
        get
        {
            return new Repository<Blog.Post>(new BlogContext());
        }
    }

    public static Repository<Blog.PostView> PostView
    {
        get
        {
            return new Repository<Blog.PostView>(new BlogContext());
        }
    }
}
