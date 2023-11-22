using Microsoft.EntityFrameworkCore;

namespace Sifh.ReportGenerator.Model
{
    public partial class SifhContext : DbContext
    {
        public SifhContext()
        {
        }

        public SifhContext(DbContextOptions<SifhContext>options)
            : base(options)
        {
        }

        public virtual DbSet<ReceivingNote> ReceivingNotes { get; set; }
        public virtual DbSet<Vessel> Vessels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceivingNote>()
                .Property(e => e.ReferenceNumber)
                .IsUnicode(false);

                
            modelBuilder.Entity<Vessel>()
                .Property(e => e.VesselName)
                .IsUnicode(false);
        }
    }
}
