using AutoMapper;
using PagedList;
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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IRepository Repository { get; private set; }

        public VehicleMakeRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IEnumerable<IVehicleMake>> GetAsync()
        {
            return Mapper.Map<IEnumerable<IVehicleMake>>(await Repository.GetWhere<VehicleMake>().OrderByDescending(r => r.id).ToListAsync());
        }


        public virtual async Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null)
        {
            if (filter != null)
            {
                var makes = Mapper.Map<IEnumerable<VehicleMakePoco>>(await Repository.GetAsync<VehicleMake>())
                    .OrderBy(c => c.Name)
                    .ToList();

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    makes = makes.Where(s => s.Name.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .OrderBy(c => c.Name)
                        .ToList();
                }

                var paged = makes.ToPagedList(filter.PageNumber, filter.PageSize);
                var makesPagedList = new StaticPagedList<VehicleMakePoco>(paged, paged.GetMetaData());
                return makesPagedList;
            }
            else
            {
                return Mapper.Map<IEnumerable<VehicleMakePoco>>(Repository.GetWhere<VehicleMake>()).ToList();
            }

        }

        public virtual async Task<IVehicleMake> GetAsync(int id)
        {
            return Mapper.Map<VehicleMakePoco>(await Repository.GetWhere<VehicleMake>().Where(c => c.id == id).FirstOrDefaultAsync());

        }

        public virtual Task<int> AddAsync(IVehicleMake VehicleMake)
        {

            return Repository.AddAsync<VehicleMake>(Mapper.Map<VehicleMake>(VehicleMake));

        }

        public virtual Task<int> UpdateAsync(IVehicleMake vehicleMake)
        {

            return Repository.UpdateAsync<VehicleMake>(Mapper.Map<VehicleMake>(vehicleMake));

        }

        public virtual Task<int> AddAsync(VehicleMake VehicleMake)
        {

            VehicleMake.id = Repository.GetWhere<VehicleMake>().OrderByDescending(a => a.id).Select(a => a.id).FirstOrDefault() + 1;
            return Repository.AddAsync(Mapper.Map<VehicleMake>(VehicleMake));

        }

        public virtual Task<int> DeleteAsync(int id)
        {

            return Repository.DeleteAsync<VehicleMake>(id);

        }

        public virtual Task<int> DeleteAsync(int? id)
        {

            return Repository.DeleteAsync<VehicleMake>(id);

        }
    }
}