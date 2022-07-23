namespace Blog;

public class Repository
{
    public static Write<Blog.Author> Author
    {
        get
        {
            return new Write<Blog.Author>(new BlogContext());
        }
    }

    public static Write<Blog.PostContent> PostContent
    {
        get
        {
            return new Write<Blog.PostContent>(new BlogContext());
        }
    }

    public static Write<Blog.Post> Post
    {
        get
        {
            return new Write<Blog.Post>(new BlogContext());
        }
    }

    public static Write<Blog.PostView> PostView
    {
        get
        {
            return new Write<Blog.PostView>(new BlogContext());
        }
    }
}
