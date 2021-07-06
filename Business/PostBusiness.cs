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
    public class PostBusiness : Business<Post, Post>
    {
        protected override Repository<Post> WriteRepository => Repository.Post;

        protected override ReadRepository<Post> ReadRepository => Repository.Post;
    }
}
