using FernandoJose.CodeFirst.Domain.Models;
using FernandoJose.CodeFirst.SqlServer.Maps;
using Microsoft.EntityFrameworkCore;

namespace FernandoJose.CodeFirst.SqlServer.Contexts
{
    public class FernandoJoseCodeFirstDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=FernandoJoseCodeFirst;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
