using PruebaOAuthKey.Models;
using Microsoft.EntityFrameworkCore;
using PruebaOAuthKey.Models;

namespace PruebaOAuthKey.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options): base(options) { }

        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
