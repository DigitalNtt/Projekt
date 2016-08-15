using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Repository.Interface
{
    public interface IRepository
    {
        IUnitOfWork CreateUnitOfWork();
        Task<List<T>> GetAsync<T>() where T : class;
        Task<T> GetByIDAsync<T>(int? id) where T : class;
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(int? id) where T : class;
        IQueryable<T> GetWhere<T>() where T : class;
    }
}
