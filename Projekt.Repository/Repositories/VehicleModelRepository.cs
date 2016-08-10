﻿using Projekt.Repository.Interface;
using AutoMapper;
using Projekt.Model.Interface;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Projekt.DAL.Entities;
using Projekt.Repository.Filters;

namespace Projekt.Repository.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IRepository Repository { get; set; }

        public VehicleModelRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public virtual async Task<IEnumerable<IVehicleModel>> GetAsync(VehicleModelFilter filter = null)
        {
            return Mapper.Map<IEnumerable<Model.VehicleModelPoco>>(Repository.GetWhere<VehicleModel>()).ToList();
        }

        public virtual async Task<IVehicleModel> GetAsync(int Id)
        {
            try
            {
                return Mapper.Map<VehicleModelPoco>(await Repository.GetWhere<VehicleModel>().Where(c => c.id == Id).FirstOrDefaultAsync());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(IVehicleModel VehicleModel)
        {
            try
            {
                return Repository.UpdateAsync(Mapper.Map<VehicleModel>(VehicleModel));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}