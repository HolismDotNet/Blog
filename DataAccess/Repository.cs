using Holism.Blog.Models;
using Holism.DataAccess;

namespace Holism.Blog.DataAccess
{
    public class Repository
    {
        public static Repository<Post> Post
        {
            get
            {
                return new Holism.DataAccess.Repository<Post>(new BlogContext());
            }
        }
        
        public static Repository<Voice> Voice
        {
            get
            {
                return new Holism.DataAccess.Repository<Voice>(new BlogContext());
            }
        }
    }
}
