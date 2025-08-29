using System.ComponentModel.DataAnnotations;

namespace ShanYue.Model
{
    public class test
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string AAAA { get; set; }
    }
}
