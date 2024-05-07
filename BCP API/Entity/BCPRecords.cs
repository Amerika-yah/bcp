using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCP_API.Entity
{
    public class BCPRecords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bcpRecID { get; set; }
        public string? BCPType { get; set; }
        public string? miscId { get; set; }
        public string? Reason { get; set; }
        public string? Remarks { get; set; }
    }
}
