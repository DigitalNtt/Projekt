using Projekt.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Projekt.DAL.Mapping
{
    internal class VehicleMakeMap : EntityTypeConfiguration<VehicleMake>
    {
        public VehicleMakeMap()
        {
            HasKey(t => t.id);

            ToTable("VehicleMakes");
            Property(t => t.id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("Name").HasColumnType("NVarchar").HasMaxLength(250);
            Property(t => t.Abrv).HasColumnName("Abrv").HasColumnType("NVarchar").HasMaxLength(50);
        }
    }
}