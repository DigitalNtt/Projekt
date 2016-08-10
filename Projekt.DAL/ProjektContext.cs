using Projekt.DAL.Entities;
using Projekt.DAL.Mapping;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System;

namespace Projekt.DAL
{
    public class ProjektContext : DbContext, IProjektContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        //
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ProjektContext() : base("name=ProjektContext")
        {
        }

        public static ProjektContext Create()
        {
            return new ProjektContext();
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VehicleMakeMap());
            modelBuilder.Configurations.Add(new VehicleModelMap());

            base.OnModelCreating(modelBuilder);
        }
    }
    public interface IProjektContext : IDisposable
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}