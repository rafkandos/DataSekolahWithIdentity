using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSekolahWithIdentity.Models
{
    public class Guru
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuruId { get; set; }

        public string NamaGuru { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Status { get; set; }
    }
}
