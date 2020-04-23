using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSekolahWithIdentity.Models
{
    public class Siswa
    {
        [Key]
        public int Id { get; set; }

        public int NIM { get; set; }

        [MaxLength(100)]
        public string Nama { get; set; }

        [Required]
        public int KelasId { get; set; }

        [ForeignKey("KelasId")]
        public virtual Kelas Kelas { get; set; }
    }
}
