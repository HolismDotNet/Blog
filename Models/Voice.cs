using System;

namespace Holism.Blog.Models
{
    public class Voice : Holism.Models.IEntity
    {
        public Voice()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
