using Holism.Business;
using Holism.DataAccess;
using Holism.Framework;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;
using Microsoft.VisualBasic;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Holism.Blog.Business
{

   public class VoiceBusiness : Business<Voice, Voice>
    {
        protected override Repository<Voice> WriteRepository => Repository.Voice;

        protected override ReadRepository<Voice> ReadRepository => Repository.Voice;
    }
}
