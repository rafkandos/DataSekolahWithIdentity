using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataSekolahWithIdentity.Models;

namespace DataSekolahWithIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppRole>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<Siswa> Siswa { get; set; }

        public DbSet<Kelas> Kelas { get; set; }

        public DbSet<Guru> Guru { get; set; }
    }
}
