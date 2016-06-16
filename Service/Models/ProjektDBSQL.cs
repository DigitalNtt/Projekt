namespace Service.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjektDBSQL : DbContext
    {
        public ProjektDBSQL()
            : base("name=ProjektDBSQL")
        {
        }

        public virtual DbSet<VehicleMake> VehicleMake { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VehicleMake>()
                .HasMany(e => e.VehicleModel)
                .WithOptional(e => e.VehicleMake)
                .HasForeignKey(e => e.MakeId);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.MakeId)
                .HasPrecision(18, 0);
        }
    }
}
