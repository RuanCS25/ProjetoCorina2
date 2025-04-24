using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoCorina2.Models;

namespace ProjetoCorina2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Classificacoe> Classificacoes { get; set; }

        public DbSet<Horario> Horarios { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<RegPresenca> RegPresencas { get; set; }

        public DbSet<RegistroAusencia> RegistroAusencias { get; set; }

        public DbSet<Aviso> Avisos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Classificacoe>().ToTable("Classificacoes");
            builder.Entity<Horario>().ToTable("Horarios");
            builder.Entity<Aluno>().ToTable("Alunos");
            builder.Entity<RegistroAusencia>().ToTable("RegistroAusencias");
            builder.Entity<RegPresenca>().ToTable("RegPresencas");
            builder.Entity<Aviso>().ToTable("Avisos");

        }
    }
}
