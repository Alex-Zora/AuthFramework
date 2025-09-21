using System;

namespace Model.Dto
{
    public class PermissionDto
    {

        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Description { get; set; } = string.Empty;

        public int type { get; set; }

    }
}