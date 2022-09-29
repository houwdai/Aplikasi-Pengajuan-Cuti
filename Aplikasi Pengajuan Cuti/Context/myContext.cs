using System.Collections.Generic;
using Aplikasi_Pengajuan_Cuti.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplikasi_Pengajuan_Cuti.Context
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext> dbContext) : base(dbContext)
        {
        }
        public DbSet<Userr> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Pegawai> pegawai { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Division> division { get; set; }
        public DbSet<Cuti> cuti { get; set; }
    }
}
