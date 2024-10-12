using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbientalEndpoints.Models;

namespace MonitoramentoAmbientalEndpoints.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<SensorModel> Sensores { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<SensorModel>(entity => {
                entity.ToTable("SENSOR");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Temperatura);
                entity.Property(e => e.Umidade);
            });
        }
        
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected DatabaseContext() { }
    }
}
