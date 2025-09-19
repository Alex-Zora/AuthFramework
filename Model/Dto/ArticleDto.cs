using System;

namespace Model.Dto
{
    public class ArticleDto
    {

        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public short Type { get; set; }

        public string Tags { get; set; }

    }
}