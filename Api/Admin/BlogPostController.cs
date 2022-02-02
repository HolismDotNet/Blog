namespace Blog;

public class BlogPostController : Controller<Blog.Post, Blog.Post>
{
    public override ReadBusiness<Blog.Post> ReadBusiness => new Blog.PostBusiness();
    
    public override Business<Blog.Post, Blog.Post> Business => new Blog.PostBusiness();

    [HttpPost]
    public Blog.Post ToggleCommentAcceptance(long id)
    {
        var post = new Blog.PostBusiness().ToggleCommentAcceptance(id);
        return post;
    }

    [FileUploadChecker]
    [HttpPost]
    public Blog.Post SetImage(IFormFile file)
    {
        var postId = Request.Query["postId"];
        if (postId.Count == 0)
        {
            throw new ClientException("Please provide postId");
        }
        var bytes = file.OpenReadStream().GetBytes();
        var post = new Blog.PostBusiness().ChangeImage(postId[0].ToLong(), bytes);
        return post;
    }
}
