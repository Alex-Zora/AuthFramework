using System;

namespace Model.Dto
{
    public class PermissionDto
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Code { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Description { get; set; }

        public int type { get; set; }

    }
}