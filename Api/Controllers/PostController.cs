using Holism.Api.Controllers;
using Holism.Business;
using Holism.Blog.Business;
using Holism.Blog.Models;

namespace Holism.Blog.Api.Controllers
{
    public class PostController : Controller<Post, Post>
    {
        public override ReadBusiness<Post> ReadBusiness => new PostBusiness();
    }
}
