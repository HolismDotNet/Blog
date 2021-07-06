using Holism.Api.Controllers;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Api.Controllers
{
    public class VoiceController : ReadController<Voice>
    {
        public override ReadBusiness<Voice> ReadBusiness => new VoiceBusiness();
    }
}
