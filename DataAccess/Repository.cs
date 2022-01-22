namespace Holism.Blog.DataAccess;

public class Repository
{
    public static Repository<PostContent> PostContent
    {
        get
        {
            return new Repository<PostContent>(new BlogContext());
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
