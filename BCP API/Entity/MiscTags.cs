using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCP_API.Entity
{
    public class MiscTags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? code { get; set; }
        public string? Definition { get; set; }
        public string? Description { get; set; }
    }
}
