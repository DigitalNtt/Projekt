using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Projekt.DAL.Entities;

namespace Projekt.DAL.Mapping
{
    class VehicleModelMap : EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelMap()
        {
            HasKey(t => t.id);

            ToTable("VehicleModels");
            Property(t => t.id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("Name").HasColumnType("NVarchar").HasMaxLength(250);
            Property(t => t.Abrv).HasColumnName("Abrv").HasColumnType("NVarchar").HasMaxLength(50);
            Property(t => t.MakeId).HasColumnName("MakeId").HasColumnType("int");

            HasRequired(t => t.VehicleMake)
                .WithMany(t => t.VehicleModels)
                .HasForeignKey(d => d.MakeId)
                .WillCascadeOnDelete(false);
        }
    }
}
