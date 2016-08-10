using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Projekt.DAL.Entities;

namespace Projekt.DAL.Mapping
{
    class VehicleMakeMap : EntityTypeConfiguration<VehicleMake>
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
