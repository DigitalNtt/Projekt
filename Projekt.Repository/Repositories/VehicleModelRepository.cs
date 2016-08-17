using AutoMapper;
using Projekt.DAL.Entities;
using Projekt.Model;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using Projekt.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Repository.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IRepository Repository { get; set; }

        public VehicleModelRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IEnumerable<IVehicleModel>> GetAsync()
        {

                return Mapper.Map<IEnumerable<IVehicleModel>>(await Repository.GetWhere<VehicleModel>().OrderByDescending(r => r.id).ToListAsync());

        }

        public virtual async Task<IEnumerable<IVehicleModel>> GetAsync(VehicleModelFilter filter = null)
        {
            return Mapper.Map<IEnumerable<Model.VehicleModelPoco>>(Repository.GetWhere<VehicleModel>()).ToList();
        }

        public virtual async Task<IVehicleModel> GetAsync(int Id)
        {

                return Mapper.Map<VehicleModelPoco>(await Repository.GetWhere<VehicleModel>().Where(c => c.id == Id).FirstOrDefaultAsync());

        }

        public virtual Task<int> AddAsync(IVehicleModel VehicleMode)
        {

                VehicleMode.id = Repository.GetWhere<VehicleModel>().OrderByDescending(a => a.id).Select(a => a.id).FirstOrDefault() + 1;
                return Repository.AddAsync<VehicleModel>(Mapper.Map<VehicleModel>(VehicleMode));

        }

        public virtual Task<int> UpdateAsync(IVehicleModel VehicleModel)
        {

                return Repository.UpdateAsync(Mapper.Map<VehicleModel>(VehicleModel));

        }

        public virtual Task<int> DeleteAsync(int? id)
        {

                return Repository.DeleteAsync<VehicleModel>(id);

        }
    }
}