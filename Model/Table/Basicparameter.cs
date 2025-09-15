using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Table
{
    public class Basicparameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IsEnd { get;set; } = string.Empty;
        public long ParentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Basicparameter Parent { get; set; } = new Basicparameter();
        public List<Basicparameter> Children { get; set; } = new List<Basicparameter>();
    }
}
