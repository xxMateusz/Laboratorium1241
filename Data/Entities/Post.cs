using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PostEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(5000)] 
        public string Content { get; set; }

        [Required]
        [MaxLength(200)]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [MaxLength(500)] 
        public string Tags { get; set; }

        [MaxLength(500)] 
        public string Comment { get; set; }
    }
}
