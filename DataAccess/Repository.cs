namespace Holism.Blog.DataAccess;

public class Repository
{
    public static Repository<BlogPostContent> BlogPostContent
    {
        get
        {
            return new Repository<BlogPostContent>(new BlogContext());
        }
    }

    public static Repository<BlogPost> BlogPost
    {
        get
        {
            return new Repository<BlogPost>(new BlogContext());
        }
    }


}
