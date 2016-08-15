using AutoMapper;
using Projekt.Repository.Interface;
using Projekt.Repository.Filters;
using System.Collections.Generic;
using Projekt.Model;
using Projekt.Model.Interface;
using Projekt.DAL.Entities;
using System.Threading.Tasks;
using System.Linq;
using PagedList;
using System;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

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
            try
            {
                return Mapper.Map<IEnumerable<IVehicleMake>>(await Repository.GetWhere<VehicleMake>().OrderByDescending(r => r.id).ToListAsync());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null)
        {
            try
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IVehicleMake> GetAsync(int id)
        {
            try
            {
                return Mapper.Map<VehicleMakePoco>(await Repository.GetWhere<VehicleMake>().Where(c => c.id == id).FirstOrDefaultAsync());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> AddAsync(IVehicleMake VehicleMake)
        {
            try
            {
                return Repository.AddAsync<VehicleMake>(Mapper.Map<VehicleMake>(VehicleMake));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(IVehicleMake vehicleMake)
        {
            try
            {
                return Repository.UpdateAsync<VehicleMake>(Mapper.Map<VehicleMake>(vehicleMake));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual Task<int> AddAsync(VehicleMake VehicleMake)
        {
            try
            {
                VehicleMake.id = Repository.GetWhere<VehicleMake>().OrderByDescending(a => a.id).Select(a => a.id).FirstOrDefault() + 1;
                return Repository.AddAsync(Mapper.Map<VehicleMake>(VehicleMake));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual Task<int> DeleteAsync(int id)
        {
            try
            {
                return Repository.DeleteAsync<VehicleMake>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual Task<int> DeleteAsync(int? id)
        {
            try
            {
                return Repository.DeleteAsync<VehicleMake>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
