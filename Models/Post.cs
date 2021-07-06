using System;

namespace Holism.Blog.Models
{
    public class Post : Holism.Models.IEntity
    {
        public Post()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public string PersianDate { get; private set; }

        public dynamic RelatedItems { get; set; }
    }
}
