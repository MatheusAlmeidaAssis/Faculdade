using Faculdade.Dominio.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Faculdade.Entity
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Faculdade")
        {

        }
        public DbSet<Aluno> Aluno { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Aluno>().Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Aluno>().Property(x => x.Mae).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento).IsRequired().HasColumnType("date");
        }
    }
}
