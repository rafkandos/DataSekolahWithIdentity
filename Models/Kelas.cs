using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSekolahWithIdentity.Models
{
    public class Kelas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KelasId { get; set; }

        public string Tingkat { get; set; }

        public string Jurusan { get; set; }

        [MaxLength(100)]
        public string WaliKelas { get; set; }
    }
}
