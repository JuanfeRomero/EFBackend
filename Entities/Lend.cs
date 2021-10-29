using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFBackEnd.Entities
{
    [Table("Lend", Schema = "dbo")]
    public class Lend
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public bool Available { get; set; }
        [Required]
        public DateTime StartOn { get; set; }
        [Required]
        public DateTime DueOn { get; set; }

        public Book Book { get; set; }

        public Member Member { get; set; }

    }
}
