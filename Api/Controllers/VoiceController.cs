using Holism.Api.Controllers;
using Holism.Business;
using Holism.Blog.Business;
using Holism.Blog.Models;

namespace Holism.Blog.Api.Controllers
{
    public class VoiceController : ReadController<Voice>
    {
        public override ReadBusiness<Voice> ReadBusiness => new VoiceBusiness();
    }
}
