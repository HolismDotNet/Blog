namespace Holism.Blog.DataAccess;

public class Repository
{
    public static Repository<Post> Post
    {
        get
        {
            return new Repository<Post>(new BlogContext());
        }
    }


}
