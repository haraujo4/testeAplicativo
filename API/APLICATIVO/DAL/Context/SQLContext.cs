using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class SQLContext : DbContext
    {

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Triagem> Triagens { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Especialidade> Especialidades{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SQLContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}