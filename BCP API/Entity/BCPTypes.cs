using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCP_API.Entity
{
    public class BCPTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bcpId { get; set; }
        public string? BCPType { get; set; }
        public string? Definition { get; set; }
        public string? Description { get; set; }
    }
}
