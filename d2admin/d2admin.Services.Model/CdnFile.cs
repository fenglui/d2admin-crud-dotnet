using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace d2admin.Services.Model
{
    [Table("CdnFile")]
    public class CdnFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Avatar { get; set; }

        [MaxLength(3000)]
        [DataType(DataType.Text)]
        public string Pictures { get; set; }

        [MaxLength(3000)]
        [DataType(DataType.Text)]
        public string Images { get; set; }

        [MaxLength(3000)]
        [DataType(DataType.Text)]
        public string Files { get; set; }

        public bool IsDeleted { get; set; }
    }
}
