using Projekt.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Projekt.DAL
{
    internal class ProjektInitializer : DropCreateDatabaseAlways<ProjektContext>
    {
        protected override void Seed(ProjektContext context)
        {
            base.Seed(context);

            var VehicleMakes = new List<VehicleMake>
            {
                new VehicleMake
                {
                    Name = "Fiat",
                    Abrv = "F!"
                },
                new VehicleMake()
                {
                    Name = "Audi",
                    Abrv = "OOOOO"
                },

                new VehicleMake()
                {
                    Name = "BMW",
                    Abrv = "+"
                }
            };
            VehicleMakes.ForEach(v => context.VehicleMakes.Add(v));
            context.SaveChanges();

            var VehicleModels = new List<VehicleModel>
            {
                new VehicleModel
                {
                    Name = "Panda",
                    Abrv = "pnd",
                    MakeId=1
                },
                new VehicleModel()
                {
                    Name = "Punto",
                    Abrv = "pnt",
                    MakeId=1
                },

                new VehicleModel()
                {
                    Name = "A4",
                    Abrv = "OOOO",
                    MakeId=2
                },

                new VehicleModel()
                {
                    Name = "X5",
                    Abrv = "5",
                    MakeId=3
                }
            };
            VehicleModels.ForEach(m => context.VehicleModels.Add(m));
            context.SaveChanges();
        }
    }
}