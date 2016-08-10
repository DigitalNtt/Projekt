using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.Repository.Interface;
using Projekt.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Projekt.Repository.Repositories
{
    public class Repository : IRepository
    {
        protected IProjektContext DbContext { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        public Repository(IProjektContext db, IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (db == null)
            {
                throw new ArgumentException("DbContext");
            }
            DbContext = db;
            UnitOfWorkFactory = unitOfWorkFactory;
        }
        public IUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkFactory.CreateUnitOfWork();
        }
        public virtual Task<List<T>> GetAsync<T>() where T : class
        {
            return DbContext.Set<T>().ToListAsync();
        }
        public virtual Task<T> GetByIDAsync<T>(Guid? id) where T : class
        {
            return DbContext.Set<T>().FindAsync(id);
        }
        public virtual async Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {
                    DbContext.Set<T>().Add(entity);
                }
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    DbContext.Set<T>().Attach(entity);
                }
                dbEntityEntry.State = EntityState.Modified;
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    DbContext.Set<T>().Attach(entity);
                    DbContext.Set<T>().Remove(entity);
                }
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<int> DeleteAsync<T>(Guid? id) where T : class
        {
            var entity = await GetByIDAsync<T>(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity with specified id not found.");
            }
            return await DeleteAsync<T>(entity);
        }
        public virtual IQueryable<T> GetWhere<T>() where T : class
        {
            return DbContext.Set<T>();
        }
    }
}
