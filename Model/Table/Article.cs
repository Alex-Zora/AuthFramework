using Model.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Table
{
    [GenerateDto]
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [SnowflakeId]
        public long Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Title {  get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public short Type { get; set; }
        public string? Tags { get; set; } = string.Empty;
    }
}
