using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.Services.Model
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(64)]
        public string Intro { get; set; }

        [MaxLength(1)]
        public string FirstLetter { get; set; }

        [MaxLength(300)]
        public string Avatar { get; set; }

        public bool IsDeleted { get; set; }
    }
}
