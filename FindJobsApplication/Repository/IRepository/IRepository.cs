﻿using System.Linq.Expressions;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
                            , string? includeProperty = null);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> entities);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    }
}