﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplication.Contracts.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        //Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        //Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null);
        Task<int> InsertAsync(T entity);
        //Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<int> UpdateAsync(T entity);
    }

}
